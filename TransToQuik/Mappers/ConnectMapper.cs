using System;
using TransToQuik.Enums;
using TransToQuik.Interfaces;

namespace TransToQuik.Mappers;

public class ConnectMapper : IQuikErrorMapper<ConnectError>
{
    public static readonly ConnectMapper Instance = new();
    private ConnectMapper() { }

    public ConnectError MapError(QuikReturnStatus status)
    {
        return status switch
        {
            QuikReturnStatus.Success => ConnectError.None,
            QuikReturnStatus.DllAlreadyConnectedToQuik => ConnectError.AlreadyConnected,
            QuikReturnStatus.QuikTerminalNotFound => ConnectError.TerminalNotFound,
            QuikReturnStatus.DllVersionNotSupported => ConnectError.DllVersionNotSupported,
            QuikReturnStatus.Failed => ConnectError.Error,
            _ => throw new NotSupportedException($"{nameof(QuikReturnStatus)}. Unknown code: {status}")
        };
    }

    public bool IsSuccess(QuikReturnStatus status) =>
          status == QuikReturnStatus.Success
          || status == QuikReturnStatus.DllAlreadyConnectedToQuik;

}
