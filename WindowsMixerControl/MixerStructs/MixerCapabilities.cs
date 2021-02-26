using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsMixerControl.MixerStructs {
    /// <summary>
    /// The <see cref="MixerCapabilities"/> structure describes the capabilities of a mixer device. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercaps">Microsoft Docs</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MixerCapabilities {
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
        /// A manufacturer identifier for the mixer device driver. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        public ushort manufacturerID;

        /// <summary>
        /// A product identifier for the mixer device driver. Product identifiers are defined in Manufacturer and Product Identifiers.
        /// </summary>
        public ushort productID;

        /// <summary>
        /// Version number of the mixer device driver. The high-order byte is the major version number, and the low-order byte is the minor version number.
        /// </summary>
        public uint driverVersion;

        /// <summary>
        /// First 32 chars of the Name of the product. If the mixer device driver supports multiple cards, this string must uniquely and easily identify (potentially to a user) the specific card.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string productName;

        /// <summary>
        /// Various support information for the mixer device driver. No extended support bits are currently defined.
        /// </summary>
        public uint fdwSupport;

        /// <summary>
        /// The number of audio line destinations available through the mixer device. All mixer devices must support at least one destination line, so this member cannot be zero. Destination indexes used in the dwDestination member of the MIXERLINE structure range from zero to the value specified in the cDestinations member minus one.
        /// </summary>
        public uint totalDestinations;
    }
}
