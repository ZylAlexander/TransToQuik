using System;
using TransToQuik.Enums;
using TransToQuik.Interfaces;

namespace TransToQuik.Mappers;

public class SimpleMapper : IQuikErrorMapper<SimpleError>
{
    public static readonly SimpleMapper Instance = new();
    private SimpleMapper() { }
    public SimpleError MapError(QuikReturnStatus status)
    {
        return status switch
        {
            QuikReturnStatus.Success => SimpleError.None,
            QuikReturnStatus.Failed => SimpleError.Error,
            _ => throw new NotSupportedException($"{nameof(QuikReturnStatus)}. Unknown code: {status}")
        };
    }
    public bool IsSuccess(QuikReturnStatus status) =>
          status == QuikReturnStatus.Success;

}
