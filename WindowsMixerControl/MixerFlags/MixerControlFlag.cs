using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl.MixerFlags {
    /// <summary>
    /// Used for Getting or Setting MixerControlDetails. Used with <see cref="NativeMethods.SetMixerControlDetails"/> and <see cref="NativeMethods.GetMixerControlDetails"/>
    /// </summary>
    [Flags]
    public enum MixerControlFlag : uint {
        Value = 0,
        ListText = 1,
        QUERYMASK = 0xF
    }
}