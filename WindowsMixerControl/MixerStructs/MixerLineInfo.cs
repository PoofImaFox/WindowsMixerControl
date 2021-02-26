using System.Runtime.InteropServices;

using WindowsMixerControl.MixerFlags;

namespace WindowsMixerControl.MixerStructs {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4, Size = 172)]
    public unsafe struct MixerLineInfo {
        /// <summary>
        /// Size, in bytes, of the <see cref="MixerLineInfo"/> structure. This member must be initialized before calling the <see cref="NativeMethods.GetMixerLineInfo(ulong, ref MixerLineInfo, MixerFlags.MixerOperationDetails)"/> function. The size specified in this member must be large enough to contain the <see cref="MixerLineInfo"/> structure. When <see cref="NativeMethods.GetMixerLineInfo(ulong, ref MixerLineInfo, MixerFlags.MixerOperationDetails)"/> returns, this member contains the actual size of the information returned. The returned information will not exceed the requested size.
        /// </summary>
        public uint structSize;

        /// <summary>
        /// This member ranges from zero to one less than the value specified in the <see cref="MixerCapabilities.totalDestinations"/> member of the <see cref="MixerCapabilities"/> structure retrieved by the <see cref="NativeMethods.GetMixerDeviceCapabilities(uint, ref MixerCapabilities, uint)"/> function. When the <see cref="NativeMethods.GetMixerLineInfo(ulong, ref MixerLineInfo, MixerFlags.MixerOperationDetails)"/> function is called with the MIXER_GETLINEINFOF_DESTINATION flag, properties for the destination line are returned. (The <see cref="source"/> member must be set to zero in this case.) When called with the MIXER_GETLINEINFOF_SOURCE flag, the properties for the source given by the <see cref="source"/> member that is associated with the <see cref="destination"/> member are returned.
        /// </summary>
        public uint destination;

        /// <summary>
        /// Index for the audio source line associated with the <see cref="destination"/> member. That is, this member specifies the Nth audio source line associated with the specified audio destination line. This member is not used for destination lines and must be set to zero when MIXER_GETLINEINFOF_DESTINATION is specified in the <see cref="NativeMethods.GetMixerLineInfo(ulong, ref MixerLineInfo, MixerFlags.MixerOperationDetails)"/> function. When the MIXER_GETLINEINFOF_SOURCE flag is specified, this member ranges from zero to one less than the value specified in the <see cref="connections"/> member for the audio destination line given in the <see cref="destination"/> member.
        /// </summary>
        public uint source;

        /// <summary>
        /// An identifier defined by the mixer device that uniquely refers to the audio line described by the <see cref="MixerLineInfo"/> structure. This identifier is unique for each mixer device and can be in any format. An application should use this identifier only as an abstract handle.
        /// </summary>
        public uint lineID;

        /// <summary>
        /// Status and support flags for the audio line. This member is always returned to the application and requires no initialization.
        /// </summary>
        public uint fdwLine;

        /// <summary>
        /// Instance data defined by the audio device for the line. This member is intended for custom mixer applications designed specifically for the mixer device returning this information. Other applications should ignore this data.
        /// </summary>
        public uint* user;

        /// <summary>
        /// Component type for this audio line. An application can use this information to display tailored graphics or to search for a particular component. If an application does not use component types, this member should be ignored.
        /// </summary>
        public MixerLineInfoComponentType componentType;

        /// <summary>
        /// Maximum number of separate channels that can be manipulated independently for the audio line. The minimum value for this field is 1 because a line must have at least one channel.
        /// </summary>
        public uint channels;

        /// <summary>
        /// Number of connections that are associated with the audio line. This member is used only for audio destination lines and specifies the number of audio source lines that are associated with it. This member is always zero for source lines and for destination lines that do not have any audio source lines associated with them.
        /// </summary>
        public uint connections;

        /// <summary>
        /// Number of controls associated with the audio line. This value can be zero. If no controls are associated with the line, the line is likely to be a source that might be selected in a MIXERCONTROL_CONTROLTYPE_MUX or MIXERCONTROL_CONTROLTYPE_MIXER but allows no manipulation of the signal.
        /// </summary>
        public uint controls;

        /// <summary>
        /// (16 chars long) Short string that describes the audio mixer line specified in the <see cref="lineID"/> member. This description should be appropriate as a concise label for the line.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string shortName;

        /// <summary>
        /// (64 chars long) String that describes the audio mixer line specified in the <see cref="lineID"/> member. This description should be appropriate as a complete description for the line.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;

        /// <summary>
        /// Target media information.
        /// </summary>
        public MixerLineTarget target;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    public unsafe struct MixerLineTarget {
        public ushort DriverMajorVersion {
            get {
                return (ushort)((driverVersion >> 16) & 0xFFFF);
            }
        }

        public ushort DriverMinorVersion {
            get {
                return (ushort)(driverVersion & 0xFFFF);
            }
        }

        /// <summary>
        /// Target media device type associated with the audio line described in the <see cref="MixerLineInfo"/> structure. An application must ignore target information for media device types it does not use. The following values are defined:
        /// </summary>
        public uint type;

        /// <summary>
        /// Current device identifier of the target media device when the <see cref="type"/> member is a target type other than MIXERLINE_TARGETTYPE_UNDEFINED. This identifier is identical to the current media device index of the associated media device. When calling the <see cref="NativeMethods.GetMixerLineInfo(ulong, ref MixerLineInfo, MixerFlags.MixerOperationDetails)"/> function with the MIXER_GETLINEINFOF_TARGETTYPE flag, this member is ignored on input and will be returned to the caller by the audio mixer manager.
        /// </summary>
        public uint deviceID;

        /// <summary>
        /// Manufacturer identifier of the target media device when the <see cref="type"/> member is a target type other than MIXERLINE_TARGETTYPE_UNDEFINED. This identifier is identical to the <see cref="MixerCapabilities.manufacturerID"/> member of the <see cref="MixerCapabilities"/> structure for the associated media. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        public ushort manufacturerID;

        /// <summary>
        /// Product identifier of the target media device when the <see cref="type"/> member is a target type other than MIXERLINE_TARGETTYPE_UNDEFINED. This identifier is identical to the <see cref="MixerCapabilities.productID"/> member of the <see cref="MixerCapabilities"/> structure for the associated media. Product identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        public ushort productID;

        /// <summary>
        /// Driver version of the target media device when the <see cref="type"/> member is a target type other than MIXERLINE_TARGETTYPE_UNDEFINED. This version is identical to the <see cref="MixerCapabilities.driverVersion"/> member of the <see cref="MixerCapabilities"/> structure for the associated media.
        /// </summary>
        public uint driverVersion;

        /// <summary>
        /// Product name of the target media device when the <see cref="type"/> member is a target type other than MIXERLINE_TARGETTYPE_UNDEFINED. This name is identical to the <see cref="MixerCapabilities.productName"/> member of the <see cref="MixerCapabilities"/> structure for the associated media.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string productName;
    }
}