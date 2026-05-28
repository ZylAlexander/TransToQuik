using System;
using System.Runtime.InteropServices;

namespace TransToQuik.Extension;

internal static class NativeStringExtensions
{
    public static string PtrToQuikString(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
        {
            return null;
        }

        var length = 0;
        while (Marshal.ReadByte(ptr, length) != 0)
        {
            length++;
        }

        if (length == 0)
        {
            return string.Empty;
        }

        var bytes = new byte[length];
        Marshal.Copy(ptr, bytes, 0, length);
        return ByteArrayEncoding.Windows1251.GetString(bytes);
    }
}
