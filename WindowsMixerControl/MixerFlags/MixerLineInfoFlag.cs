using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl.MixerFlags {

    /// <summary>
    /// Flags for retrieving information about an audio line. The following values are defined.
    /// </summary>
    [Flags]
    public enum MixerLineInfoFlag : uint {
        /// <summary>
        /// The pmxl parameter will receive information about the destination audio line specified by the dwDestination member of the MIXERLINE structure. This index ranges from zero to one less than the value in the cDestinations member of the MIXERCAPS structure. All remaining structure members except cbStruct require no further initialization.
        /// </summary>
        Destination = 0,

        /// <summary>
        /// The pmxl parameter will receive information about the source audio line specified by the dwDestination and dwSource members of the MIXERLINE structure. The index specified by dwDestination ranges from zero to one less than the value in the cDestinations member of the MIXERCAPS structure. The index specified by dwSource ranges from zero to one less than the value in the cConnections member of the MIXERLINE structure returned for the audio line stored in the dwDestination member. All remaining structure members except cbStruct require no further initialization.
        /// </summary>
        Source = 1,

        /// <summary>
        /// The pmxl parameter will receive information about the audio line specified by the dwLineID member of the MIXERLINE structure. This is usually used to retrieve updated information about the state of an audio line. All remaining structure members except cbStruct require no further initialization.
        /// </summary>
        LineID = 2,

        /// <summary>
        /// The pmxl parameter will receive information about the first audio line of the type specified in the dwComponentType member of the MIXERLINE structure. This flag is used to retrieve information about an audio line of a specific component type. Remaining structure members except cbStruct require no further initialization.
        /// </summary>
        ComponentType = 3,

        /// <summary>
        /// The pmxl parameter will receive information about the audio line that is for the dwType member of the Target structure, which is a member of the MIXERLINE structure. This flag is used to retrieve information about an audio line that handles the target type (for example, MIXERLINE_TARGETTYPE_WAVEOUT). The application must initialize the dwType, wMid, wPid, vDriverVersion and szPname members of the MIXERLINE structure before calling mixerGetLineInfo. All of these values can be retrieved from the device capabilities structures for all media devices. Remaining structure members except cbStruct require no further initialization.
        /// </summary>
        TargetType = 4,

        QueryMask = 0xF
    }
}
