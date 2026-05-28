using System;
using Xunit;
using TransToQuik.Models.Transactions;
using TransToQuik.Enums;
using TransToQuik.Models.Transactions.KillTransaction;

namespace TransToQuik.Tests
{
    public class TransactionsTests
    {
        [Fact]
        public void QuikNewOrder_ToString_ReturnsExpectedString()
        {
            var order = new QuikNewOrder
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                ClientCode = "CL1",
                Operation = QuikOperation.Buy,
                Quantity = 10,
                Price = 100.5,
                Type = QuikTypeOrder.Limit,
                ExecutionCondition = QuikExecutionCondition.PutInQueue
            };

            var expected = $"ACTION=NEW_ORDER;TRANS_ID={order.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;CLIENT_CODE=CL1;OPERATION=B;QUANTITY=10;PRICE=100.50;TYPE=L;EXECUTION_CONDITION=PUT_IN_QUEUE;";
            var actual = order.ToQuikString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuikNewOrder_WithPriceScaleZero_FormatsIntegerPrice()
        {
            var order = new QuikNewOrder
            {
                ClassCode = "QJSIM",
                Account = "ACC1",
                SecCode = "LKOH",
                Operation = QuikOperation.Buy,
                Quantity = 1,
                Price = 5000,
                PriceScale = 0,
                Type = QuikTypeOrder.Limit,
            };

            var actual = order.ToQuikString();
            Assert.Contains("PRICE=5000;", actual);
            Assert.DoesNotContain("5000.00", actual);
        }

        [Fact]
        public void QuickSimpleStopOrder_ToString_ReturnsExpectedString()
        {
            var order = new QuikSimpleStopOrder
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                ClientCode = "CL1",
                Operation = QuikOperation.Buy,
                Quantity = 10,
                Price = 100.5,
                Type = QuikTypeOrder.Limit,
                StopPrice = 99.5,
                ExpiryDate = QuikExpiryDate.Gtc,

            };

            var expected = $"ACTION=NEW_STOP_ORDER;TRANS_ID={order.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;CLIENT_CODE=CL1;OPERATION=B;QUANTITY=10;PRICE=100.50;TYPE=L;STOPPRICE=99.50;STOP_ORDER_KIND=SIMPLE_STOP_ORDER;EXPIRY_DATE=GTC;";
            var actual = order.ToQuikString();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void QuikTakeProfitStopOrder_ToString_ReturnsExpectedString()
        {
            var order = new QuikTakeProfitStopOrder
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                ClientCode = "CL1",
                Operation = QuikOperation.Buy,
                Quantity = 10,
                Price = 100.5,
                Type = QuikTypeOrder.Limit,
                StopPrice = 99.5,
                ExpiryDate = QuikExpiryDate.Gtc,
                Offset = 0.5,
                OffsetUnits = QuikUnits.PriceUnits,
                Spread = 0.1,
                SpreadUnits = QuikUnits.PriceUnits
            };

            var expected = $"ACTION=NEW_STOP_ORDER;TRANS_ID={order.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;CLIENT_CODE=CL1;OPERATION=B;QUANTITY=10;PRICE=100.50;TYPE=L;STOPPRICE=99.50;STOP_ORDER_KIND=TAKE_PROFIT_STOP_ORDER;EXPIRY_DATE=GTC;OFFSET=0.50;OFFSET_UNITS=PRICE_UNITS;SPREAD=0.10;SPREAD_UNITS=PRICE_UNITS;";
            var actual = order.ToQuikString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuikTakeProfitAndStopLimitOrder_ToString_ReturnsExpectedString()
        {
            var order = new QuikTakeProfitAndStopLimitOrder
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                ClientCode = "CL1",
                Operation = QuikOperation.Buy,
                Quantity = 10,
                Price = 100.5,
                Type = QuikTypeOrder.Limit,
                StopPrice = 99.5,
                ExpiryDate = QuikExpiryDate.Gtc,
                Offset = 0.5,
                OffsetUnits = QuikUnits.PriceUnits,
                Spread = 0.1,
                SpreadUnits = QuikUnits.PriceUnits,
                StopPrice2 = 98.5,
                MarketStopLimit = QuikYesNo.No,
                MarketTakeProfit = QuikYesNo.No,
                IsActiveInTime = QuikYesNo.Yes,
                ActiveFromTime = new DateTime(2025, 7, 29, 10, 0, 0),
                ActiveToTime = new DateTime(2025, 7, 29, 18, 0, 0)
            };

            var expected = $"ACTION=NEW_STOP_ORDER;TRANS_ID={order.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;CLIENT_CODE=CL1;OPERATION=B;QUANTITY=10;PRICE=100.50;TYPE=L;STOPPRICE=99.50;STOP_ORDER_KIND=TAKE_PROFIT_AND_STOP_LIMIT_ORDER;EXPIRY_DATE=GTC;OFFSET=0.50;OFFSET_UNITS=PRICE_UNITS;SPREAD=0.10;SPREAD_UNITS=PRICE_UNITS;STOPPRICE2=98.50;MARKET_STOP_LIMIT=NO;MARKET_TAKE_PROFIT=NO;IS_ACTIVE_IN_TIME=YES;ACTIVE_FROM_TIME=100000;ACTIVE_TO_TIME=180000;";
            var actual = order.ToQuikString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuikConditionPriceByOtherSecStopOrder_ToString_ReturnsExpectedString()
        {
            var order = new QuikConditionPriceByOtherSecStopOrder
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                ClientCode = "CL1",
                Operation = QuikOperation.Buy,
                Quantity = 10,
                Price = 100.5,
                Type = QuikTypeOrder.Limit,
                StopPrice = 99.5,
                ExpiryDate = QuikExpiryDate.Gtc,
                StopPriceSeccode = "GAZP",
                StopPriceClasscode = "EQBR",
                StopPriceCondition = QuikStopPriceCondition.MoreOrEqual
            };

            var expected = $"ACTION=NEW_STOP_ORDER;TRANS_ID={order.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;CLIENT_CODE=CL1;OPERATION=B;QUANTITY=10;PRICE=100.50;TYPE=L;STOPPRICE=99.50;STOP_ORDER_KIND=CONDITION_PRICE_BY_OTHER_SEC;EXPIRY_DATE=GTC;STOPPRICE_CLASSCODE=EQBR;STOPPRICE_SECCODE=GAZP;STOPPRICE_CONDITION=>=;";
            var actual = order.ToQuikString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuikActivatedByOrderSimpleStopOrder_ToString_ReturnsExpectedString()
        {
            var order = new QuikActivatedByOrderSimpleStopOrder
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                ClientCode = "CL1",
                Operation = QuikOperation.Buy,
                Quantity = 10,
                Price = 100.5,
                Type = QuikTypeOrder.Limit,
                StopPrice = 99.5,
                ExpiryDate = QuikExpiryDate.Gtc,
                BaseOrderKey = 12345,
                UseBaseOrderBalance = QuikYesNo.Yes,
                ActivateIfBaseOrderPartlyFilled = QuikYesNo.No
            };

            var expected = $"ACTION=NEW_STOP_ORDER;TRANS_ID={order.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;CLIENT_CODE=CL1;OPERATION=B;QUANTITY=10;PRICE=100.50;TYPE=L;STOPPRICE=99.50;STOP_ORDER_KIND=ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER;EXPIRY_DATE=GTC;BASE_ORDER_KEY=12345;USE_BASE_ORDER_BALANCE=YES;ACTIVATE_IF_BASE_ORDER_PARTLY_FILLED=NO;";
            var actual = order.ToQuikString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuikKillOrderTransaction_ToString_ReturnsExpectedString()
        {
            var transaction = new QuikKillOrderTransaction
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                OrderKey = 12345
            };

            var expected = $"ACTION=KILL_ORDER;TRANS_ID={transaction.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;ORDER_KEY=12345;";
            var actual = transaction.ToQuikString();
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void QuikKillStopOrderTransaction_ToString_ReturnsExpectedString()
        {
            var transaction = new QuikKillStopOrderTransaction
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                StopOrderKey = 12345
            };

            var expected = $"ACTION=KILL_STOP_ORDER;TRANS_ID={transaction.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;STOP_ORDER_KEY=12345;";
            var actual = transaction.ToQuikString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuikKillNegDealTransaction_ToString_ReturnsExpectedString()
        {
            var transaction = new QuikKillNegDealTransaction
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                OrderKey = 12345
            };

            var expected = $"ACTION=KILL_NEG_DEAL;TRANS_ID={transaction.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;ORDER_KEY=12345;";
            var actual = transaction.ToQuikString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QuikKillQuoteTransaction_ToString_ReturnsExpectedString()
        {
            var transaction = new QuikKillQuoteTransaction
            {
                ClassCode = "EQBR",
                Account = "ACC1",
                SecCode = "SBER",
                OrderKey = 12345
            };

            var expected = $"ACTION=KILL_QUOTE;TRANS_ID={transaction.TransId};ACCOUNT=ACC1;CLASSCODE=EQBR;SECCODE=SBER;ORDER_KEY=12345;";
            var actual = transaction.ToQuikString();
            Assert.Equal(expected, actual);
        }
    }
}
