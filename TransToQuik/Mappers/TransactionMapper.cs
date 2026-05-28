using System;
using TransToQuik.Enums;
using TransToQuik.Interfaces;

namespace TransToQuik.Mappers;

public class TransactionMapper : IQuikErrorMapper<TransactionError>
{
    public static readonly TransactionMapper Instance = new();
    private TransactionMapper() { }

    public TransactionError MapError(QuikReturnStatus status)
    {
        return status switch
        {
            QuikReturnStatus.Success => TransactionError.None,
            QuikReturnStatus.Failed => TransactionError.Error,
            QuikReturnStatus.WrongSyntax => TransactionError.WrongSyntax,
            QuikReturnStatus.QuikNotConnected => TransactionError.QuikNotConnected,
            QuikReturnStatus.DllNotConnected => TransactionError.DllNotConnected,
            _ => throw new NotSupportedException($"{nameof(QuikReturnStatus)}. Unknown code: {status}")
        };
    }

    public bool IsSuccess(QuikReturnStatus status) =>
          status == QuikReturnStatus.Success;

}