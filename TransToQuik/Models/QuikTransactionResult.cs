using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models;

public readonly record struct QuikTransactionResult
{
    public QuikReplyCode ReplyCode { get; }
    public uint TransId { get; }
    public ulong OrderNum { get; }
    public string ResultMessage { get; }
    public bool Success { get; }
    public int? ExtendedErrorCode { get; }
    public string Message { get; }
    public TransactionError ErrorKind { get; }

    public QuikTransactionResult(
        QuikResult<TransactionError> baseResult,
        int replyCode,
        uint transId,
        ulong orderNum,
        string resultMessage)
    {
        ExtendedErrorCode = baseResult.ExtendedErrorCode;
        Message = baseResult.Message;
        ResultMessage = resultMessage;
        OrderNum = orderNum;
        TransId = transId;

        QuikReplyCodeExtensions.TryParse(replyCode, out var parsedReplyCode);
        ReplyCode = parsedReplyCode;

        var replySucceeded = parsedReplyCode.IsSuccessfulOutcome();
        Success = baseResult.Success && replySucceeded;
        ErrorKind = baseResult.Success switch
        {
            false => baseResult.ErrorKind,
            true when replySucceeded => TransactionError.None,
            _ => TransactionError.Error,
        };
    }

}
