using System.Text;

namespace TransToQuik.Extension;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendIfNotEmpty(this StringBuilder sb, string key, string value, string separator = ";")
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            sb
            .Append(key)
            .Append('=')
            .Append(value)
            .Append(separator);
        }
        return sb;
    }
}