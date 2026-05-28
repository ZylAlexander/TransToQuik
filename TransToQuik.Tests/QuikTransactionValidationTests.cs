using TransToQuik.Enums;
using TransToQuik.Models.Transactions;
using Xunit;

namespace TransToQuik.Tests;

public class QuikTransactionValidationTests
{
    [Fact]
    public void Validate_FailsWhenClassCodeMissingForNewOrder()
    {
        var order = new QuikNewOrder
        {
            ClassCode = "",
            Account = "ACC",
            SecCode = "SBER",
            Operation = QuikOperation.Buy,
            Quantity = 1,
            Price = 1,
        };

        var result = order.Validate();

        Assert.False(result.IsValid);
        Assert.Contains("ClassCode", result.ErrorMessage);
    }

    [Fact]
    public void Validate_FailsWhenAccountMissing()
    {
        var order = new QuikNewOrder
        {
            ClassCode = "TQBR",
            Account = "  ",
            SecCode = "SBER",
            Operation = QuikOperation.Buy,
            Quantity = 1,
            Price = 1,
        };

        var result = order.Validate();

        Assert.False(result.IsValid);
        Assert.Contains("Account", result.ErrorMessage);
    }

    [Fact]
    public void Validate_StopOrderFailsWhenBaseOrderValidationFails()
    {
        var order = new QuikSimpleStopOrder
        {
            ClassCode = "TQBR",
            Account = "ACC",
            SecCode = "SBER",
            Operation = QuikOperation.Buy,
            Quantity = 0,
            Price = 100,
            StopPrice = 99,
            ExpiryDate = QuikExpiryDate.Gtc
        };

        var result = order.Validate();

        Assert.False(result.IsValid);
        Assert.Contains("Quantity", result.ErrorMessage);
    }

    [Fact]
    public void Validate_SimpleStopOrderAllowsMissingExpiryDate()
    {
        var order = new QuikSimpleStopOrder
        {
            ClassCode = "TQBR",
            Account = "ACC",
            SecCode = "SBER",
            Operation = QuikOperation.Buy,
            Quantity = 1,
            Price = 100,
            StopPrice = 99
        };

        var result = order.Validate();

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_ConditionPriceByOtherSecFailsWhenStopPriceNegative()
    {
        var order = new QuikConditionPriceByOtherSecStopOrder
        {
            ClassCode = "TQBR",
            Account = "ACC",
            SecCode = "SBER",
            Operation = QuikOperation.Buy,
            Quantity = 1,
            Price = 100,
            StopPrice = -1,
            ExpiryDate = QuikExpiryDate.Gtc,
            StopPriceClasscode = "TQBR",
            StopPriceSeccode = "GAZP",
            StopPriceCondition = QuikStopPriceCondition.MoreOrEqual
        };

        var result = order.Validate();

        Assert.False(result.IsValid);
        Assert.Contains("StopPrice", result.ErrorMessage);
    }

    [Fact]
    public void Validate_TakeProfitAndStopLimitFailsWhenActiveWindowMissing()
    {
        var order = new QuikTakeProfitAndStopLimitOrder
        {
            ClassCode = "TQBR",
            Account = "ACC",
            SecCode = "SBER",
            Operation = QuikOperation.Buy,
            Quantity = 1,
            Price = 100,
            StopPrice = 99,
            ExpiryDate = QuikExpiryDate.Gtc,
            Offset = 0.5,
            OffsetUnits = QuikUnits.PriceUnits,
            Spread = 0.1,
            SpreadUnits = QuikUnits.PriceUnits,
            StopPrice2 = 98,
            MarketStopLimit = QuikYesNo.No,
            MarketTakeProfit = QuikYesNo.No,
            IsActiveInTime = QuikYesNo.Yes,
            ActiveFromTime = default,
            ActiveToTime = default
        };

        var result = order.Validate();

        Assert.False(result.IsValid);
        Assert.Contains("must be specified", result.ErrorMessage);
    }
}
