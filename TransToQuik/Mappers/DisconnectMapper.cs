using System;
using TransToQuik.Enums;
using TransToQuik.Interfaces;

namespace TransToQuik.Mappers;

public class DisconnectMapper : IQuikErrorMapper<DisconnectError>
{
    public static readonly DisconnectMapper Instance = new();
    private DisconnectMapper() { }

    public DisconnectError MapError(QuikReturnStatus status)
    {
        return status switch
        {
            QuikReturnStatus.Success => DisconnectError.None,
            QuikReturnStatus.DllNotConnected => DisconnectError.DllNotConnected,
            QuikReturnStatus.Failed => DisconnectError.Error,
            _ => throw new NotSupportedException($"{nameof(QuikReturnStatus)}. Unknown code: {status}")
        };
    }

    public bool IsSuccess(QuikReturnStatus status) =>
          status == QuikReturnStatus.Success ||
          status == QuikReturnStatus.DllNotConnected;

}
