using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl.MixerFlags {

    [Flags]
    public enum MixerControlType : uint {
        Custom = (MixerControlConstants.MIXERCONTROL_CT_CLASS_CUSTOM | MixerControlConstants.MIXERCONTROL_CT_UNITS_CUSTOM),
        Booleanmeter = (MixerControlConstants.MIXERCONTROL_CT_CLASS_METER | MixerControlConstants.MIXERCONTROL_CT_SC_METER_POLLED | MixerControlConstants.MIXERCONTROL_CT_UNITS_BOOLEAN),
        Signedmeter = (MixerControlConstants.MIXERCONTROL_CT_CLASS_METER | MixerControlConstants.MIXERCONTROL_CT_SC_METER_POLLED | MixerControlConstants.MIXERCONTROL_CT_UNITS_SIGNED),
        Peakmeter = (Signedmeter + 1),
        Unsignedmeter = (MixerControlConstants.MIXERCONTROL_CT_CLASS_METER | MixerControlConstants.MIXERCONTROL_CT_SC_METER_POLLED | MixerControlConstants.MIXERCONTROL_CT_UNITS_UNSIGNED),
        Boolean = (MixerControlConstants.MIXERCONTROL_CT_CLASS_SWITCH | MixerControlConstants.MIXERCONTROL_CT_SC_SWITCH_BOOLEAN | MixerControlConstants.MIXERCONTROL_CT_UNITS_BOOLEAN),
        Onoff = (Boolean + 1),
        Mute = (Boolean + 2),
        Mono = (Boolean + 3),
        Loudness = (Boolean + 4),
        Stereoenh = (Boolean + 5),
        Bass_boost = (Boolean + 0x00002277),
        Button = (MixerControlConstants.MIXERCONTROL_CT_CLASS_SWITCH | MixerControlConstants.MIXERCONTROL_CT_SC_SWITCH_BUTTON | MixerControlConstants.MIXERCONTROL_CT_UNITS_BOOLEAN),
        Decibels = (MixerControlConstants.MIXERCONTROL_CT_CLASS_NUMBER | MixerControlConstants.MIXERCONTROL_CT_UNITS_DECIBELS),
        Signed = (MixerControlConstants.MIXERCONTROL_CT_CLASS_NUMBER | MixerControlConstants.MIXERCONTROL_CT_UNITS_SIGNED),
        Unsigned = (MixerControlConstants.MIXERCONTROL_CT_CLASS_NUMBER | MixerControlConstants.MIXERCONTROL_CT_UNITS_UNSIGNED),
        Percent = (MixerControlConstants.MIXERCONTROL_CT_CLASS_NUMBER | MixerControlConstants.MIXERCONTROL_CT_UNITS_PERCENT),
        Slider = (MixerControlConstants.MIXERCONTROL_CT_CLASS_SLIDER | MixerControlConstants.MIXERCONTROL_CT_UNITS_SIGNED),
        Pan = (Slider + 1),
        Qsoundpan = (Slider + 2),
        Fader = (MixerControlConstants.MIXERCONTROL_CT_CLASS_FADER | MixerControlConstants.MIXERCONTROL_CT_UNITS_UNSIGNED),
        Volume = (Fader + 1),
        Bass = (Fader + 2),
        Treble = (Fader + 3),
        Equalizer = (Fader + 4),
        Singleselect = (MixerControlConstants.MIXERCONTROL_CT_CLASS_LIST | MixerControlConstants.MIXERCONTROL_CT_SC_LIST_SINGLE | MixerControlConstants.MIXERCONTROL_CT_UNITS_BOOLEAN),
        Mux = (Singleselect + 1),
        Multipleselect = (MixerControlConstants.MIXERCONTROL_CT_CLASS_LIST | MixerControlConstants.MIXERCONTROL_CT_SC_LIST_MULTIPLE | MixerControlConstants.MIXERCONTROL_CT_UNITS_BOOLEAN),
        Mixer = (Multipleselect + 1),
        Microtime = (MixerControlConstants.MIXERCONTROL_CT_CLASS_TIME | MixerControlConstants.MIXERCONTROL_CT_SC_TIME_MICROSECS | MixerControlConstants.MIXERCONTROL_CT_UNITS_UNSIGNED),
        Millitime = (MixerControlConstants.MIXERCONTROL_CT_CLASS_TIME | MixerControlConstants.MIXERCONTROL_CT_SC_TIME_MILLISECS | MixerControlConstants.MIXERCONTROL_CT_UNITS_UNSIGNED)
    }
}