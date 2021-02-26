using System.Runtime.InteropServices;
using System.Text;

using WindowsMixerControl.MixerFlags;
using WindowsMixerControl.MixerStructs;

namespace WindowsMixerControl {
    /// <summary>
    /// Native methods to call from <c>winmm.dll</c>. <a href="https://docs.microsoft.com/en-us/windows/win32/multimedia/audio-mixer-reference">Microsoft Docs</a>
    /// </summary>
    internal static unsafe class NativeMethods {
        /// <summary>
        /// The <see cref="GetMixerDevicesCount"/> function retrieves the number of mixer devices present in the system. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetnumdevs">Microsoft Docs</a>
        /// </summary>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerGetNumDevs", SetLastError = true)]
        public static extern uint GetMixerDevicesCount();

        /// <summary>
        /// The <see cref="GetMixerDeviceCapabilities"/> function queries a specified mixer device to determine its capabilities. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetdevcaps">Microsoft Docs</a>
        /// </summary>
        /// <param name="deviceID"></param>
        /// <param name="mixerCapabilities"></param>
        /// <param name="mixerCapabilitiesStructSize"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerGetDevCaps", SetLastError = true)]
        public static extern uint GetMixerDeviceCapabilities(uint deviceID, ref MixerCapabilities mixerCapabilities, uint mixerCapabilitiesStructSize);

        /// <summary>
        /// The <see cref="OpenMixerDeviceHandle"/> function opens a specified mixer device and ensures that the device will not be removed until the application closes the handle. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixeropen">Microsoft Docs</a>
        /// </summary>
        /// <param name="mixerDeviceHandle"></param>
        /// <param name="mixerDeviceID"></param>
        /// <param name="callback"></param>
        /// <param name="instance"></param>
        /// <param name="mixerOperationDetails"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerOpen", SetLastError = true)]
        public static extern MixerOperationResult OpenMixerDeviceHandle(ref ulong mixerDeviceHandle, uint mixerDeviceID, uint* callback, uint* instance, uint mixerOperationFlags);

        /// <summary>
        /// The <see cref="GetMixerDeviceID"/> function retrieves the device identifier for a mixer device associated with a specified device handle. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetnumdevs">Microsoft Docs</a>
        /// </summary>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerGetID", SetLastError = true)]
        public static extern MixerOperationResult GetMixerDeviceID(ulong mixerDeviceHandle, ref uint deviceID, uint mixerOperationFlags);

        /// <summary>
        /// The <see cref="CloseMixerDeviceHandle"/> function closes the specified mixer device. a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixerclose">Microsoft Docs</a>
        /// </summary>
        /// <param name="mixerDeviceHandle"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerClose", SetLastError = true)]
        public static extern MixerOperationResult CloseMixerDeviceHandle(ulong mixerDeviceHandle);

        /// <summary>
        /// The <see cref="GetMixerControlDetails"/> function retrieves details about a single control associated with an audio line. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetcontroldetails">Microsoft Docs</a>
        /// </summary>
        /// <param name="mixerDeviceHandle"></param>
        /// <param name="mixerControlDetails"></param>
        /// <param name="mixerOperationDetails"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerGetControlDetails", SetLastError = true)]
        public static extern MixerOperationResult GetMixerControlDetails(ulong mixerDeviceHandle, ref MixerControlDetails mixerControlDetails, uint mixerOperationFlags);

        /// <summary>
        /// The <see cref="SetMixerControlDetails"/> function sets properties of a single control associated with an audio line. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixersetcontroldetails">Microsoft Docs</a>
        /// </summary>
        /// <param name="mixerDeviceHandle"></param>
        /// <param name="mixerControlDetails"></param>
        /// <param name="mixerOperationDetails"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerSetControlDetails", SetLastError = true)]
        public static extern MixerOperationResult SetMixerControlDetails(ulong mixerDeviceHandle, ref MixerControlDetails mixerControlDetails, uint mixerOperationFlags);

        /// <summary>
        /// The <see cref="GetMixerLineInfo"/> function retrieves information about a specific line of a mixer device. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetlineinfo">Microsoft Docs</a>
        /// </summary>
        /// <param name="mixerDeviceHandle"></param>
        /// <param name="mixerLineInfo"></param>
        /// <param name="mixerOperationDetails"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerGetLineInfo", SetLastError = true)]
        public static extern MixerOperationResult GetMixerLineInfo(ulong mixerDeviceHandle, ref MixerLineInfo mixerLineInfo, uint mixerOperationFlags);

        /// <summary>
        /// The <see cref="GetMixerLineControls"/> function retrieves one or more controls associated with an audio line. <a href="https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetlinecontrols">Microsoft Docs</a>
        /// </summary>
        /// <param name="mixerDeviceHandle"></param>
        /// <param name="mixerLineInfo"></param>
        /// <param name="mixerOperationFlags"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mixerGetLineControls", SetLastError = true)]
        public static extern MixerOperationResult GetMixerLineControls(ulong mixerDeviceHandle, ref MixerLineControls mixerLineInfo, uint mixerOperationFlags);

        /// <summary>
        /// The <see cref="GetErrorString"/> function retrieves a string that describes the specified MCI error code.
        /// </summary>
        /// <param name="error"></param>
        /// <param name="errorText"></param>
        /// <param name="charCountErrorText"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "mciGetErrorString", SetLastError = true)]
        public static extern MixerOperationResult GetErrorString(int error, StringBuilder errorText, uint charCountErrorText);

        /// <summary>
        /// Retrieves a handle to the default heap of the calling process. This handle can then be used in subsequent calls to the heap functions. <a href="https://docs.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-getprocessheap">Microsoft Docs</a>
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "GetProcessHeap", SetLastError = false)]
        public static extern void* GetHeapHandle();

        /// <summary>
        /// Frees a memory block allocated from a heap by the <see cref="Malloc"/> or <c>HeapReAlloc</c> function. a href="https://docs.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapfree">Microsoft Docs</a>
        /// </summary>
        /// <param name="heapHandle"></param>
        /// <param name="memoryFlags"></param>
        /// <param name="heapPtr"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "HeapFree", SetLastError = false)]
        public static extern bool Free(void* heapHandle, MallocMemoryFlags memoryFlags, void* heapPtr);

        /// <summary>
        /// Allocates a block of memory from a heap. The allocated memory is not movable. a href="https://docs.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapalloc">Microsoft Docs</a>
        /// </summary>
        /// <param name="heapHandle"></param>
        /// <param name="memoryFlags"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "HeapAlloc", SetLastError = false)]
        public static extern void* Malloc(void* heapHandle, MallocMemoryFlags memoryFlags, uint size);
    }
}