using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsMixerControl {
    public unsafe static class NativeMemory {
        public static void* HeapHandle { get; private set; }

        static NativeMemory() {
            HeapHandle = NativeMethods.GetHeapHandle();
        }

        public static IEnumerable<T> ReadStructArrayFromMemory<T>(int count, IntPtr mixerControlArrayPtr) {
            var structSize = Marshal.SizeOf<T>();

            for (var x = 0; x < count; x++) {
                yield return ReadStructFromMemory<T>(mixerControlArrayPtr, x * structSize);
            }
        }

        public static T ReadStructFromMemory<T>(IntPtr pointer, int offset) {
            var managedStruct = (T)Marshal.PtrToStructure(pointer + offset, typeof(T));
            return managedStruct;
        }

        public static IntPtr WriteStructArrayToMemory<T>(T[] structArray) {
            var dataStructSize = Marshal.SizeOf<T>();
            var controlStructSize = structArray.Length * dataStructSize;
            var memoryPtr = new IntPtr(NativeMethods.Malloc(HeapHandle, MallocMemoryFlags.heapZeroMemory, (uint)controlStructSize));

            for (var x = 0; x < structArray.Length; x++) {
                var dataStruct = structArray[x];
                Marshal.StructureToPtr(dataStruct, memoryPtr + (dataStructSize * x), true);
            }
            return memoryPtr;
        }

        public static IntPtr WriteStructToMemory<T>(T dataStruct) {
            var controlStructSize = Marshal.SizeOf(dataStruct);

            var memoryPtr = new IntPtr(NativeMethods.Malloc(HeapHandle, MallocMemoryFlags.heapZeroMemory, (uint)controlStructSize));
            Marshal.StructureToPtr(dataStruct, memoryPtr, true);
            return memoryPtr;
        }
    }
}
