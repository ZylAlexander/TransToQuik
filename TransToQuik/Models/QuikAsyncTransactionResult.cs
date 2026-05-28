using TransToQuik.Enums;

namespace TransToQuik.Models;

public readonly record struct QuikAsyncTransactionResult
{
    public QuikReplyCode ReplyCode { get; }
    public uint TransId { get; }
    public ulong OrderNum { get; }
    public string ResultMessage { get; }
    public bool Success { get; }
    public long? ExtendedErrorCode { get; }
    public string Message { get; }
    public TransactionError ErrorKind { get; }    
    public QuikTransactionReplySnapshot Reply { get; }

    public QuikAsyncTransactionResult(
        QuikTransactionResult baseResult,
        QuikTransactionReplySnapshot reply)
    {
        Success = baseResult.Success;
        ExtendedErrorCode = baseResult.ExtendedErrorCode;
        Message = baseResult.Message;
        ErrorKind = baseResult.ErrorKind;
        ReplyCode = baseResult.ReplyCode;
        OrderNum = baseResult.OrderNum;
        TransId = baseResult.TransId;
        ResultMessage = baseResult.ResultMessage;
        Reply = reply;
    }
}
