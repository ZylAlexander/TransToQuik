using TransToQuik;
using Xunit;

namespace TransToQuik.Tests;

public class CallbackDispatcherTests
{
    [Fact]
    public void TryRegisterWaiter_ReturnsFalse_WhenTransactionIdAlreadyRegistered()
    {
        const long transId = 42_001;

        Assert.True(CallbackDispatcher.TryRegisterWaiter(transId, default, out var first));
        Assert.False(CallbackDispatcher.TryRegisterWaiter(transId, default, out var second));
        Assert.Null(second);

        CallbackDispatcher.RemoveWaiter(transId);
    }
}
