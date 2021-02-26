using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using WindowsMixerControl.MixerFlags;
using WindowsMixerControl.MixerStructs;

namespace WindowsMixerControl {
    public unsafe class MixerDeviceControl {
        private readonly MixerControl _mixerControl;
        private readonly MixerLineInfo _mixerLineInfo;
        private readonly ulong _mixerDeviceHandle;

        public uint ControlID {
            get {
                return _mixerControl.controlID;
            }
        }

        public MixerControlType ControlType {
            get {
                return _mixerControl.controlType;
            }
        }

        public string Name {
            get {
                return _mixerControl.name;
            }
        }

        public uint MinimumValue {
            get {
                return _mixerControl.minimumValue;
            }
        }

        public uint MaximumValue {
            get {
                return _mixerControl.maximumValue;
            }
        }

        public MixerDeviceControl(MixerControl mixerControl, MixerLineInfo mixerLineInfo, ulong mixerDeviceHandle) {
            _mixerControl = mixerControl;
            _mixerLineInfo = mixerLineInfo;
            _mixerDeviceHandle = mixerDeviceHandle;
        }

        public void SetValue(uint unsignedValue) {
            var memortPtr = NativeMemory.WriteStructToMemory(new MixerControlDetailsUnSigned() {
                value = unsignedValue > MaximumValue ? MaximumValue : unsignedValue
            });

            SetValue(memortPtr);
        }

        public void SetValue(int signedValue) {
            var memortPtr = NativeMemory.WriteStructToMemory(new MixerControlDetailsSigned() {
                value = signedValue > (int)MaximumValue ? (int)MaximumValue : signedValue
            });

            SetValue(memortPtr);
        }

        public void SetValue(bool toggleValue) {
            var memortPtr = NativeMemory.WriteStructToMemory(new MixerControlDetailsBoolean() {
                value = (uint)(toggleValue ? 1 : 0)
            });

            SetValue(memortPtr);
        }

        private void SetValue(IntPtr memLocation) {
            var controlDetails = new MixerControlDetails() {
                controlID = _mixerControl.controlID,
                channels = _mixerLineInfo.channels,
                detailsStructSize = 4,
                detailsStruct = memLocation
            };
            controlDetails.structSize = (uint)Marshal.SizeOf(controlDetails);

            SetControlStateInformation(controlDetails);
        }

        private void SetControlStateInformation(MixerControlDetails controlInformation, MixerControlFlag controlFlag = MixerControlFlag.Value) {
            var response = NativeMethods.SetMixerControlDetails(_mixerDeviceHandle,
                ref controlInformation, (uint)MixerDeviceAccessFlag.HMixer | (uint)controlFlag);

            WindowsMixer.SetLastError(response);

            // We no longer need this heap region.
            NativeMethods.Free(NativeMemory.HeapHandle, MallocMemoryFlags.Empty, controlInformation.detailsStruct.ToPointer());
        }

        public bool GetToggleValue() {
            return GetValue() > 0;
        }

        public int GetSignedValue() {
            return (int)GetValue();
        }

        public uint GetUnSignedValue() {
            return GetValue();
        }

        private uint GetValue() {
            var valueLocation = NativeMethods.Malloc(NativeMemory.HeapHandle, MallocMemoryFlags.heapZeroMemory, 4);

            var controlDetails = new MixerControlDetails() {
                controlID = _mixerControl.controlID,
                channels = _mixerLineInfo.channels,
                detailsStructSize = 4,
                detailsStruct = new IntPtr(valueLocation)
            };
            controlDetails.structSize = (uint)Marshal.SizeOf(controlDetails);

            GetControlStateInformation(controlDetails);

            return *(uint*)valueLocation;
        }

        private MixerControlDetails GetControlStateInformation(MixerControlDetails controlInformation, MixerControlFlag controlFlag = MixerControlFlag.Value) {
            var response = NativeMethods.GetMixerControlDetails(_mixerDeviceHandle,
                ref controlInformation, (uint)MixerDeviceAccessFlag.HMixer | (uint)controlFlag);

            WindowsMixer.SetLastError(response);
            return controlInformation;
        }
    }
}
