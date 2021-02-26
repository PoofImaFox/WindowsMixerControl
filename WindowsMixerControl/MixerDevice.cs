using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using WindowsMixerControl.MixerFlags;
using WindowsMixerControl.MixerStructs;

namespace WindowsMixerControl {
    public unsafe class MixerDevice {
        private readonly ulong _mixerDeviceHandle;

        /// <summary>
        /// Device ID as specified in the ctor.
        /// </summary>
        public uint DeviceID { get; set; }

        /// <summary>
        /// Speakers and output devices will always be described in destination devices.
        /// </summary>
        public MixerLineInfo DestinationMixerLineInfo { get; set; }

        /// <summary>
        /// Microphones and input devices will always be described in source devices.
        /// </summary>
        public MixerLineInfo SourceMixerLineInfo { get; set; }

        /// <summary>
        /// Exposes the control options available for the mixer device. It seems any controls applied to either end of the line applies.
        /// </summary>
        public List<MixerDeviceControl> MixerDestinationDeviceControls { get; set; } = new List<MixerDeviceControl>();

        /// <summary>
        /// Exposes the control options available for the mixer device. It seems any controls applied to either end of the line applies.
        /// </summary>
        public List<MixerDeviceControl> MixerSourceDeviceControls { get; set; } = new List<MixerDeviceControl>();

        public MixerDevice(uint deviceID) {
            DeviceID = deviceID;

            var response = NativeMethods.OpenMixerDeviceHandle(ref _mixerDeviceHandle, deviceID,
                null, null, (uint)MixerDeviceAccessFlag.Mixer);
            WindowsMixer.SetLastError(response);

            DestinationMixerLineInfo = GetMixerLineInfo(MixerLineInfoFlag.Destination);
            SourceMixerLineInfo = GetMixerLineInfo(MixerLineInfoFlag.Source);

            foreach (var control in GetMixerLineControls(DestinationMixerLineInfo)) {
                MixerDestinationDeviceControls.Add(new MixerDeviceControl(control, DestinationMixerLineInfo, _mixerDeviceHandle));
            }

            foreach (var control in GetMixerLineControls(SourceMixerLineInfo)) {
                MixerSourceDeviceControls.Add(new MixerDeviceControl(control, SourceMixerLineInfo, _mixerDeviceHandle));
            }
        }

        ~MixerDevice() {
            var response = NativeMethods.CloseMixerDeviceHandle(_mixerDeviceHandle);
            WindowsMixer.SetLastError(response);
        }

        public MixerLineInfo GetMixerLineInfo(MixerLineInfoFlag mixerLineInfoFlag) {
            var mixerlineInfo = new MixerLineInfo();
            mixerlineInfo.structSize = (uint)Marshal.SizeOf(mixerlineInfo);

            var response = NativeMethods.GetMixerLineInfo(_mixerDeviceHandle, ref mixerlineInfo,
                (uint)MixerDeviceAccessFlag.HMixer | (uint)mixerLineInfoFlag);

            WindowsMixer.SetLastError(response);

            return mixerlineInfo;
        }

        public MixerControl[] GetMixerLineControls(MixerLineInfo mixerLine) {
            var mixerControlArraySize = mixerLine.controls * (uint)Marshal.SizeOf<MixerControl>();
            var mixerControlArrayPtr = NativeMethods.Malloc(NativeMemory.HeapHandle, MallocMemoryFlags.Empty, mixerControlArraySize);

            var mixerLineControlsStruct = new MixerLineControls() {
                lineID = mixerLine.lineID,
                controlCount = mixerLine.controls,
                mixerControlStructSize = (uint)Marshal.SizeOf<MixerControl>(),
                mixerControlArrayPtr = mixerControlArrayPtr
            };
            mixerLineControlsStruct.structSize = (uint)Marshal.SizeOf(mixerLineControlsStruct);

            var response = NativeMethods.GetMixerLineControls(_mixerDeviceHandle, ref mixerLineControlsStruct,
                (uint)MixerDeviceAccessFlag.HMixer | (uint)MixerLineControlsFlag.All);
            WindowsMixer.SetLastError(response);

            NativeMethods.Free(NativeMemory.HeapHandle, MallocMemoryFlags.Empty, mixerControlArrayPtr);
            return NativeMemory.ReadStructArrayFromMemory<MixerControl>((int)mixerLine.controls, new IntPtr(mixerControlArrayPtr)).ToArray();
        }
    }
}