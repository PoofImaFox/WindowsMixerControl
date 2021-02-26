using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsMixerControl {
    /// <summary>
    /// HeapAlloc dwFlags <a href="https://docs.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapalloc">Microsoft Docs</a>
    /// </summary>
    [Flags]
    public enum MallocMemoryFlags : uint {
        /// <summary>
        /// No flags set in bit field.
        /// </summary>
        Empty = 0x0,

        /// <summary>
        /// The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
        /// </summary>
        HeapNoSerialize = 0x1,

        /// <summary>
        /// Serialized access will not be used for this allocation.
        /// </summary>
        HeapGenerateException = 0x4,

        /// <summary>
        /// The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.
        /// </summary>
        heapZeroMemory = 0x8
    }
}
