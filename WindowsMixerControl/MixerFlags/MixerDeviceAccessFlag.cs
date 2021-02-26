using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl.MixerFlags {
    /// <summary>
    /// Used to specify the access type for a mixer device.
    /// </summary>
    [Flags]
    public enum MixerDeviceAccessFlag : uint {
        Mixer = 0x0,
        Handle = 0x80000000,
        HMixer = (Handle | Mixer),
        Waveout = 0x10000000,
        HWaveout = (Handle | Waveout),
        Wavein = 0x20000000,
        HWavein = (Handle | Wavein),
        MidiOut = 0x30000000,
        HMidiOut = (Handle | MidiOut),
        MidiIn = 0x40000000,
        HMidiIn = (Handle | MidiIn),
        Auxiliary = 0x50000000
    }
}