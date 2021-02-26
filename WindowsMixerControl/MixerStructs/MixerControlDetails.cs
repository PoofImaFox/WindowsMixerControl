using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsMixerControl.MixerStructs {
    /// <summary>
    /// The <see cref="MixerControlDetails"/> structure refers to control-detail structures, retrieving or setting state information of an audio mixer control. All members of this structure must be initialized before calling the <see cref="NativeMethods.GetMixerControlDetails"/> and <see cref="NativeMethods.SetMixerControlDetails"/> functions. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails">Microsoft Docs</a> for more information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public unsafe struct MixerControlDetails {
        /// <summary>
        /// Size, in bytes, of the <see cref="MixerControlDetails"/> structure. The size must be large enough to contain the base <see cref="MixerControlDetails"/> structure. When <see cref="NativeMethods.GetMixerControlDetails"/> returns, this member contains the actual size of the information returned. The returned information will not exceed the requested size, nor will it be smaller than the base <see cref="MixerControlDetails"/> structure.
        /// </summary>
        public uint structSize;

        /// <summary>
        /// Control identifier on which to get or set properties.
        /// </summary>
        public uint controlID;

        /// <summary>
        /// Number of channels on which to get or set control properties.
        /// </summary>
        public uint channels;

        /// <summary>
        /// Union of windows handle and cMultipleItems. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails">See more...</a>
        /// </summary>
        public IntPtr hwndOwnerUnionMultipleItems;

        /// <summary>
        /// Size, in bytes, of one of the details structures being used.
        /// </summary>
        public uint detailsStructSize;

        /// <summary>
        /// Pointer to an array of one or more structures in which properties for the specified control are retrieved or set.
        /// </summary>
        public IntPtr detailsStruct;
    }

    /// <summary>
    /// The <see cref="MixerControlDetailsBoolean"/> structure retrieves and sets Boolean control properties for an audio mixer control. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_listtext">Microsoft Docs</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MixerControlDetailsBoolean {
        /// <summary>
        /// 32bit Boolean value for a single item or channel. This value is assumed to be zero for a FALSE state (such as off or disabled), and nonzero for a TRUE state (such as on or enabled).
        /// </summary>
        public uint value;
    }

    /// <summary>
    /// The <see cref="MixerControlDetailsSigned"/> structure retrieves and sets signed type control properties for an audio mixer control. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_listtext">Microsoft Docs</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MixerControlDetailsSigned {
        /// <summary>
        /// Signed integer value for a single item or channel. This value must be inclusively within the bounds given in the Bounds member of this structure for signed integer controls.
        /// </summary>
        public int value;
    }

    /// <summary>
    /// The <see cref="MixerControlDetailsSigned"/> structure retrieves and sets unsigned type control properties for an audio mixer control. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_listtext">Microsoft Docs</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MixerControlDetailsUnSigned {
        /// <summary>
        /// Unsigned integer value for a single item or channel. This value must be inclusively within the bounds given in the Bounds structure member of the <see cref="MixerControl"/> structure for unsigned integer controls.
        /// </summary>
        public uint value;
    }

    /// <summary>
    /// The <see cref="MixerControlDetailsListText"/> structure retrieves list text, label text, and/or band-range information for multiple-item controls. This structure is used when the MIXER_GETCONTROLDETAILSF_LISTTEXT flag is specified in the <see cref="NativeMethods.GetMixerControlDetails"/> function. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_listtext">Microsoft Docs</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MixerControlDetailsListText {
        /// <summary>
        /// Control class-specific values.
        /// </summary>
        public uint param1;

        /// <summary>
        /// See dwParam1
        /// </summary>
        public uint param2;

        /// <summary>
        /// Name describing a single item in a multiple-item control. This text can be used as a label or item text, depending on the control class.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
    }
}