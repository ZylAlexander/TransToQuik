using TransToQuik;
using TransToQuik.Enums;
using TransToQuik.Mappers;
using TransToQuik.Models;
using Xunit;

namespace TransToQuik.Tests;

public class QuikTransactionResultTests
{
  [Theory]
  [InlineData((int)QuikReturnStatus.Success, (int)QuikReplyCode.Executed, true)]
  [InlineData((int)QuikReturnStatus.Success, (int)QuikReplyCode.AcceptedAfterRestrictionViolation, true)]
  [InlineData((int)QuikReturnStatus.Success, (int)QuikReplyCode.LimitCheckFailed, false)]
  [InlineData((int)QuikReturnStatus.Success, (int)QuikReplyCode.NotExecutedBySystem, false)]
  [InlineData((int)QuikReturnStatus.Success, (int)QuikReplyCode.SentToServer, false)]
  [InlineData((int)QuikReturnStatus.Failed, (int)QuikReplyCode.Executed, false)]
  public void From_ReplyCodeDeterminesTransactionSuccess(int dllResult, int replyCode, bool expectedSuccess)
  {
    var baseResult = QuikResultFactory.From(
      dllResult,
      0,
      string.Empty,
      TransactionMapper.Instance);

    var transactionResult = QuikTransactionResultFactory.From(
      baseResult,
      replyCode,
      transId: 1,
      orderNum: 0,
      resultMessage: "test");

    Assert.Equal(expectedSuccess, transactionResult.Success);
    Assert.Equal((QuikReplyCode)replyCode, transactionResult.ReplyCode);
  }

  [Fact]
  public void From_DllSuccessWithLimitCheckFailed_SetsTransactionError()
  {
    var baseResult = QuikResultFactory.From(
      (int)QuikReturnStatus.Success,
      0,
      string.Empty,
      TransactionMapper.Instance);

    var transactionResult = QuikTransactionResultFactory.From(
      baseResult,
      (int)QuikReplyCode.LimitCheckFailed,
      transId: 1,
      orderNum: 0,
      resultMessage: "limit");

    Assert.False(transactionResult.Success);
    Assert.Equal(TransactionError.Error, transactionResult.ErrorKind);
  }
}
