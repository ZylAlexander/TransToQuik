using System;
using System.Text;

namespace TransToQuik;

internal static class ByteArrayEncoding
{
    private static readonly Lazy<Encoding> _encoding = new(() =>
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        return Encoding.GetEncoding("windows-1251");
    });

    public static Encoding Windows1251 => _encoding.Value;
}
