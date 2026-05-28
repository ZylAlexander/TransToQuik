using System;
using TransToQuik.Enums;
using TransToQuik.Interfaces;

namespace TransToQuik.Mappers;

public class SubscribeMapper : IQuikErrorMapper<SubscribeError>
{
    public static readonly SubscribeMapper Instance = new();
    private SubscribeMapper() { }

    public SubscribeError MapError(QuikReturnStatus status)
    {
        return status switch
        {
            QuikReturnStatus.Success => SubscribeError.None,
            QuikReturnStatus.QuikNotConnected => SubscribeError.QuikNotConnected,
            QuikReturnStatus.DllNotConnected => SubscribeError.DllNotConnected,
            QuikReturnStatus.Failed => SubscribeError.Error,
            _ => throw new NotSupportedException($"{nameof(QuikReturnStatus)}. Unknown code: {status}")
        };
    }

    public bool IsSuccess(QuikReturnStatus status) =>
          status == QuikReturnStatus.Success;

}
