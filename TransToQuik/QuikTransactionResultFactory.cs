using TransToQuik.Enums;
using TransToQuik.Mappers;
using TransToQuik.Models;

namespace TransToQuik;

internal static class QuikTransactionResultFactory
{
    public static QuikTransactionResult From(
        int result,
        int extCode,
        string errorMessage,
        int replyCode,
        uint transId,
        ulong orderNum,
        string resultMessage)
    {
        var baseResult = QuikResultFactory.From(result, extCode, errorMessage, TransactionMapper.Instance);
        return From(baseResult, replyCode, transId, orderNum, resultMessage);
    }
    public static QuikTransactionResult From(
            QuikResult<TransactionError> baseResult,
            int replyCode,
            uint transId,
            ulong orderNum,
            string resultMessage) =>
        new(
            baseResult,
            replyCode,
            transId,
            orderNum,
            resultMessage);

}
