using System;
using System.Text;

namespace TransToQuik.Extension;

public static class ByteArrayExtensions
{
    public static string AsString(this byte[] array)
    {
        var endIndex = Array.IndexOf(array, (byte)0);

        return ByteArrayEncoding.Windows1251.GetString(array, 0, endIndex == -1 ? array.Length : endIndex);
    }
}


