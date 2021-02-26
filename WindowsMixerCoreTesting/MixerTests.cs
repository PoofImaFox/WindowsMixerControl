using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

using WindowsMixerControl;
using WindowsMixerControl.MixerFlags;
using WindowsMixerControl.MixerStructs;

using Xunit;

namespace WindowsMixerCoreTesting {
    public class MixerTests {
        [Fact]
        public void TestSetVolume() {
            var devices = WindowsMixer.FindAllDevices(MixerLineInfoComponentType.Wavein);

            foreach (var device in devices) {
                var volumeControl = device.MixerDestinationDeviceControls.Single(i => i.ControlType == MixerControlType.Volume);
                var currentVolume = volumeControl.GetUnSignedValue();
                volumeControl.SetValue(currentVolume);
            }
        }

        [Fact]
        public void TestMuteDevices() {
            var deviceComponent = MixerLineInfoComponentType.Wavein;

            WindowsMixer.MuteAllDevices(deviceComponent);
            AssertAllMuteValues(deviceComponent, true);

            WindowsMixer.UnMuteAllDevices(deviceComponent);
            AssertAllMuteValues(deviceComponent, false);
        }

        private void AssertAllMuteValues(MixerLineInfoComponentType deviceComponent, bool value) {
            var microphones = WindowsMixer.FindAllDevices(deviceComponent).ToArray();

            foreach (var microphone in microphones) {
                if (microphone.MixerSourceDeviceControls.Any(i => i.ControlType == MixerControlType.Mute)) {
                    var muteControl = microphone.MixerSourceDeviceControls.Single(i => i.ControlType == MixerControlType.Mute);
                    Assert.Equal(value, muteControl.GetToggleValue());
                }
            }
        }
    }
}