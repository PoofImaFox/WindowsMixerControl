using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using WindowsMixerControl.MixerFlags;
using WindowsMixerControl.MixerStructs;

namespace WindowsMixerControl {
    public static class WindowsMixer {
        public static void MuteAllDevices(MixerLineInfoComponentType componentType) {
            var microphones = FindAllDevices(componentType).ToArray();

            foreach (var microphone in microphones) {
                if (microphone.MixerSourceDeviceControls.Any(i => i.ControlType == MixerControlType.Mute)) {
                    var muteControl = microphone.MixerSourceDeviceControls.Single(i => i.ControlType == MixerControlType.Mute);
                    muteControl.SetValue(true);
                }
            }
        }

        public static void UnMuteAllDevices(MixerLineInfoComponentType componentType) {
            var microphones = FindAllDevices(componentType).ToArray();

            foreach (var microphone in microphones) {
                if (microphone.MixerSourceDeviceControls.Any(i => i.ControlType == MixerControlType.Mute)) {
                    var muteControl = microphone.MixerSourceDeviceControls.Single(i => i.ControlType == MixerControlType.Mute);
                    muteControl.SetValue(false);
                }
            }
        }

        public static IEnumerable<MixerDevice> FindAllDevices(MixerLineInfoComponentType componentType) {
            var devices = GetMixerDevices().ToArray();

            foreach (var device in devices) {
                // This class has a de-constructor, do not worry about open handles.
                var mixerDevice = new MixerDevice(device.deviceID);

                if (mixerDevice.DestinationMixerLineInfo.componentType == componentType
                    || mixerDevice.SourceMixerLineInfo.componentType == componentType) {
                    yield return mixerDevice;
                }
            }
        }

        public static IEnumerable<(uint deviceID, MixerCapabilities mixerCapabilities)> GetMixerDevices() {
            for (uint x = 0; x < NativeMethods.GetMixerDevicesCount(); x++) {
                var mixerCapabilities = new MixerCapabilities();
                NativeMethods.GetMixerDeviceCapabilities(x, ref mixerCapabilities, (uint)Marshal.SizeOf(mixerCapabilities));
                yield return (x, mixerCapabilities);
            }
        }

        public static void SetLastError(MixerOperationResult response) {
            if (response != MixerOperationResult.MMSYSERR_NOERROR) {
                throw new Exception(response.ToString());
            }
        }
    }
}