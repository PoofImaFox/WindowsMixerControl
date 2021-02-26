using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using WindowsMixerControl.MixerFlags;

namespace WindowsMixerControl.MixerStructs {
    /// <summary>
    /// The <see cref="MixerControl"/> structure describes the state and metrics of a single control for an audio line. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontrola">Microsoft Doc</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MixerControl {
        /// <summary>
        /// Size, in bytes, of the <see cref="MixerControl"/> structure.
        /// </summary>
        public uint structSize;

        /// <summary>
        /// Audio mixer-defined identifier that uniquely refers to the control described by the <see cref="MixerControl"/> structure. This identifier can be in any format supported by the mixer device. An application should use this identifier only as an abstract handle. No two controls for a single mixer device can ever have the same control identifier.
        /// </summary>
        public uint controlID;

        /// <summary>
        /// Class of the control for which the identifier is specified in <see cref="controlID"/>. An application must use this information to display the appropriate control for input from the user. An application can also display tailored graphics based on the control class or search for a particular control class on a specific line. If an application does not know about a control class, this control must be ignored.
        /// </summary>
        public MixerControlType controlType;

        /// <summary>
        /// Status and support flags for the audio line control.
        /// </summary>
        public uint controlFlags;

        /// <summary>
        /// Number of items per channel that make up a MIXERCONTROL_CONTROLF_MULTIPLE control. This number is always two or greater for multiple-item controls. If the control is not a multiple-item control, do not use this member; it will be zero.
        /// </summary>
        public uint multipleItems;

        /// <summary>
        /// Short string that describes the audio line control specified by <see cref="controlID"/>. This description should be appropriate to use as a concise label for the control.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string shortName;

        /// <summary>
        /// String that describes the audio line control specified by <see cref="controlID"/>. This description should be appropriate to use as a complete description for the control.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;

        /// <summary>
        /// Minimum unsigned value for a control that has an unsigned boundary nature. This member cannot be used in conjunction with lMinimum. To used signed value initialize with int, and cast to uint.
        /// </summary>
        public uint minimumValue;

        /// <summary>
        /// Maximum unsigned value for a control that has an unsigned boundary nature. This member cannot be used in conjunction with lMaximum. To used signed value initialize with int, and cast to uint.
        /// </summary>
        public uint maximumValue;
        public uint reserved_1;
        public uint reserved_2;
        public uint reserved_3;
        public uint reserved_4;

        /// <summary>
        /// Number of discrete ranges within the union specified for a control specified by the Bounds member. This member overlaps with the other members of the Metrics structure member and cannot be used in conjunction with those members.
        /// </summary>
        public uint stepsUnionCustomData;
        public uint mReserved_1;
        public uint mReserved_2;
        public uint mReserved_3;
        public uint mReserved_4;
        public uint mReserved_5;
    }
}
