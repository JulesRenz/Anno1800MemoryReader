using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Anno1800MemoryReader
{
    class MemoryHelper
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


       
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public static long ReadAddress(Process process, long address)
        {
            byte[] buffer = new byte[8];
            int bytesRead = 0;
            ReadProcessMemory(process.Handle.ToInt32(), address, buffer, 8, ref bytesRead);
            return BitConverter.ToInt64(buffer, 0);
        }

        public static int ReadIntFromNestedPointer(Process process, long baseAddress, int[] offsets)
        {
            long targetAddress = baseAddress;
            for(int i=0;i<offsets.Length-1;i++)
            {
                targetAddress = ReadAddress(process, targetAddress + offsets[i]);
            }
            return (int)ReadAddress(process, targetAddress + offsets[offsets.Length-1]);
        }
    }
}