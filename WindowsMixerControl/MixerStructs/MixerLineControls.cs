using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsMixerControl.MixerStructs {
    /// <summary>
    /// The <see cref="MixerLineControls"/> structure contains information about the controls of an audio line. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixerlinecontrols">Microsoft Doc</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    public unsafe struct MixerLineControls {
        /// <summary>
        /// Size, in bytes, of the <see cref="MixerLineControls"/> structure. This member must be initialized before calling the <see cref="NativeMethods.GetMixerLineControls"/> function. The size specified in this member must be large enough to contain the <see cref="MixerLineControls"/> structure. When <see cref="NativeMethods.GetMixerLineControls"/> returns, this member contains the actual size of the information returned. The returned information will not exceed the requested size, nor will it be smaller than the <see cref="MixerLineControls"/> structure.
        /// </summary>
        public uint structSize;

        /// <summary>
        /// Line identifier for which controls are being queried. This member is not used if the MIXER_GETLINECONTROLSF_ONEBYID flag is specified for the <see cref="NativeMethods.GetMixerLineControls"/> function, but the mixer device still returns this member in this case. The <see cref="controlIDUnionControlType"/> members are not used when MIXER_GETLINECONTROLSF_ALL is specified.
        /// </summary>
        public uint lineID;

        /// <summary>
        /// dwControlID Union dwControlType See more <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixerlinecontrols">Microsoft Doc</a>
        /// </summary>
        public uint controlIDUnionControlType;

        /// <summary>
        /// Number of <see cref="MixerControl"/> structure elements to retrieve. This member must be initialized by the application before calling the <see cref="NativeMethods.GetMixerLineControls"/> function. This member can be 1 only if MIXER_GETLINECONTROLSF_ONEBYID or MIXER_GETLINECONTROLSF_ONEBYTYPE is specified or the value returned in the <see cref="MixerLineInfo.controls"/> member of the MIXERLINE structure returned for an audio line. This member cannot be zero. If an audio line specifies that it has no controls, <see cref="NativeMethods.GetMixerLineControls"/> should not be called.
        /// </summary>
        public uint controlCount;

        /// <summary>
        /// Size, in bytes, of a single <see cref="MixerControl"/> structure. The size specified in this member must be at least large enough to contain the base <see cref="MixerControl"/> structure. The total size, in bytes, required for the buffer pointed to by the <see cref="mixerControlArrayPtr"/> member is the product of the <see cref="mixerControlStructSize"/> and <see cref="MixerLineInfo.controls"/> members of the <see cref="MixerControls"/> structure.
        /// </summary>
        public uint mixerControlStructSize;

        /// <summary>
        /// Pointer to one or more <see cref="MixerControl"/> structures to receive the properties of the requested audio line controls. This member cannot be NULL and must be initialized before calling the <see cref="NativeMethods.GetMixerLineControls"/> function. Each element of the array of controls must be at least large enough to contain a base <see cref="MixerControl"/> structure. The <see cref="mixerControlStructSize"/> member must specify the size, in bytes, of each element in this array. No initialization of the buffer pointed to by this member is required by the application. All members are filled in by the mixer device (including the <see cref="MixerControl.structSize"/> member of each <see cref="MixerControl"/> structure) upon returning successfully.
        /// </summary>
        public void* mixerControlArrayPtr;
    }
}