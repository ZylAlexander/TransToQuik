using TransToQuik.Extension;

namespace TransToQuik;

/// <summary>
/// Буфер сообщения QUIK на один вызов API (не потокобезопасен для совместного использования).
/// </summary>
internal sealed class NativeBuffer
{
    private readonly byte[] _bytes;

    public NativeBuffer(uint size) => _bytes = new byte[size];

    public byte[] Bytes => _bytes;

    public string AsString() => _bytes.AsString();
}
