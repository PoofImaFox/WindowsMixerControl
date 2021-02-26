using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Diagnostics;
using System.Linq;

using WindowsMixerControl;
using WindowsMixerControl.MixerFlags;

namespace WindowsMixerFrameworkTesting {
    [TestClass]
    public class MixerTests {
        [TestMethod]
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
                    Assert.AreEqual(value, muteControl.GetToggleValue());
                }
            }
        }
    }
}