using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl {
    public static class MixerControlConstants {
        public const uint MIXERCONTROL_CT_CLASS_MASK = 0xF0000000;
        public const uint MIXERCONTROL_CT_CLASS_CUSTOM = 0x00000000;
        public const uint MIXERCONTROL_CT_CLASS_METER = 0x10000000;
        public const uint MIXERCONTROL_CT_CLASS_SWITCH = 0x20000000;
        public const uint MIXERCONTROL_CT_CLASS_NUMBER = 0x30000000;
        public const uint MIXERCONTROL_CT_CLASS_SLIDER = 0x40000000;
        public const uint MIXERCONTROL_CT_CLASS_FADER = 0x50000000;
        public const uint MIXERCONTROL_CT_CLASS_TIME = 0x60000000;
        public const uint MIXERCONTROL_CT_CLASS_LIST = 0x70000000;

        public const uint MIXERCONTROL_CT_SUBCLASS_MASK = 0x0F000000;

        public const uint MIXERCONTROL_CT_SC_SWITCH_BOOLEAN = 0x00000000;
        public const uint MIXERCONTROL_CT_SC_SWITCH_BUTTON = 0x01000000;

        public const uint MIXERCONTROL_CT_SC_METER_POLLED = 0x00000000;

        public const uint MIXERCONTROL_CT_SC_TIME_MICROSECS = 0x00000000;
        public const uint MIXERCONTROL_CT_SC_TIME_MILLISECS = 0x01000000;

        public const uint MIXERCONTROL_CT_SC_LIST_SINGLE = 0x00000000;
        public const uint MIXERCONTROL_CT_SC_LIST_MULTIPLE = 0x01000000;

        public const uint MIXERCONTROL_CT_UNITS_MASK = 0x00FF0000;
        public const uint MIXERCONTROL_CT_UNITS_CUSTOM = 0x00000000;
        public const uint MIXERCONTROL_CT_UNITS_BOOLEAN = 0x00010000;
        public const uint MIXERCONTROL_CT_UNITS_SIGNED = 0x00020000;
        public const uint MIXERCONTROL_CT_UNITS_UNSIGNED = 0x00030000;
        public const uint MIXERCONTROL_CT_UNITS_DECIBELS = 0x00040000;
        public const uint MIXERCONTROL_CT_UNITS_PERCENT = 0x00050000;
    }
}
