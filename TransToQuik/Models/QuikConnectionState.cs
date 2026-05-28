using System;
using TransToQuik.Enums;

namespace TransToQuik.Models;

public record QuikConnectionState(QuikReturnStatus Code, string Message)
{
    private static QuikReturnStatus Convert(int code)
    {
        if (!Enum.IsDefined(typeof(QuikReturnStatus), code))
        {
            throw new ArgumentOutOfRangeException(nameof(code), $"Unknown QuikReturnStatus code: {code}");
        }

        return (QuikReturnStatus)code;
    }
    public string Status => Code.ToString();

    public QuikConnectionState(int code, string message)
    : this(Convert(code), message)
    { }

    public override string ToString()
    {
        return $"[{Status}] {Message}";
    }
}
