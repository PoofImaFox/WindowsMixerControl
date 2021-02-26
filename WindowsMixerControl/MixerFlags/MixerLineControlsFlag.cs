using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl.MixerFlags {
    /// <summary>
    /// Used to specify what line controls to select.
    /// </summary>
    [Flags]
    public enum MixerLineControlsFlag : uint {
        All = 0,
        OneByID = 1,
        OneByType = 2,
        QueryMask = 0xF
    }
}