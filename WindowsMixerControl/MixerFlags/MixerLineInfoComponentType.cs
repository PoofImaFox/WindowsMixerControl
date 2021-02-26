using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl.MixerFlags {
    /// <summary>
    /// Component type for this audio line. An application can use this information to display tailored graphics or to search for a particular component. If an application does not use component types, this member should be ignored. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixerline">Microsoft Docs</a>
    /// </summary>
    [Flags]
    public enum MixerLineInfoComponentType : uint {
        Undefined = 0x0,
        Digital = 0x1,
        Line = 0x2,
        Monitor = 0x3,
        Speakers = 0x4,
        Headphones = 0x5,
        Telephone = 0x6,
        Wavein = 0x7,
        Voicein = 0x8,
        SrcUndefined = 0x1000,
        SrcDigital = 0x1001,
        SrcLine = 0x1002,
        SrcMicrophone = 0x1003,
        SrcSynthesizer = 0x1004,
        SrcCompactdisc = 0x1005,
        SrcTelephone = 0x1006,
        SrcPcspeaker = 0x1007,
        SrcWaveout = 0x1008,
        SrcAuxiliary = 0x10
    }
}
