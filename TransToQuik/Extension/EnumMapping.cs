using System;
using TransToQuik.Enums;

namespace TransToQuik.Extension;

public static class EnumMapping
{
    public static string AsString(this QuikAction action) =>
        action switch
        {
            QuikAction.NewOrder => "NEW_ORDER",
            QuikAction.NewNegDeal => "NEW_NEG_DEAL",
            QuikAction.NewRepoNegDeal => "NEW_REPO_NEG_DEAL",
            QuikAction.NewExtRepoNegDeal => "NEW_EXT_REPO_NEG_DEAL",
            QuikAction.NewStopOrder => "NEW_STOP_ORDER",
            QuikAction.KillOrder => "KILL_ORDER",
            QuikAction.KillNegDeal => "KILL_NEG_DEAL",
            QuikAction.KillStopOrder => "KILL_STOP_ORDER",
            QuikAction.KillAllOrders => "KILL_ALL_ORDERS",
            QuikAction.KillAllStopOrders => "KILL_ALL_STOP_ORDERS",
            QuikAction.KillAllNegDeals => "KILL_ALL_NEG_DEALS",
            QuikAction.KillAllFuturesOrders => "KILL_ALL_FUTURES_ORDERS",
            QuikAction.MoveOrders => "MOVE_ORDERS",
            QuikAction.NewQuote => "NEW_QUOTE",
            QuikAction.KillQuote => "KILL_QUOTE",
            QuikAction.NewReport => "NEW_REPORT",
            QuikAction.SetFutLimit => "SET_FUT_LIMIT",
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };

    public static string AsString(this QuikExecutionCondition executionCondition) =>
        executionCondition switch
        {
            QuikExecutionCondition.PutInQueue => "PUT_IN_QUEUE",
            QuikExecutionCondition.FillOrKill => "FILL_OR_KILL",
            QuikExecutionCondition.KillBalance => "KILL_BALANCE",
            _ => throw new ArgumentOutOfRangeException(nameof(executionCondition), executionCondition, null)
        };

    public static string AsString(this QuikExpiryDate expiryDate) =>
        expiryDate switch
        {
            QuikExpiryDate.Gtc => "GTC",
            QuikExpiryDate.Today => "TODAY",
            _ => throw new ArgumentOutOfRangeException(nameof(expiryDate), expiryDate, null)
        };

    public static string AsString(this QuikForAccount forAccount) =>
        forAccount switch
        {
            QuikForAccount.OwnOwn => "OWNOWN",
            QuikForAccount.OwnCli => "OWNCLI",
            QuikForAccount.OwnDup => "OWNDUP",
            QuikForAccount.CliCli => "CLICLI",
            _ => throw new ArgumentOutOfRangeException(nameof(forAccount), forAccount, null)
        };

    public static string AsString(this QuikOperation operation) =>
            operation switch
            {
                QuikOperation.Buy => "B",
                QuikOperation.Sell => "S",
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };

    public static string AsString(this QuikStopOrderKind stopOrderKind) =>
        stopOrderKind switch
        {
            QuikStopOrderKind.SimpleStopOrder => "SIMPLE_STOP_ORDER",
            QuikStopOrderKind.ConditionPriceByOtherSec => "CONDITION_PRICE_BY_OTHER_SEC",
            QuikStopOrderKind.WithLinkedLimitOrder => "WITH_LINKED_LIMIT_ORDER",
            QuikStopOrderKind.TakeProfitStopOrder => "TAKE_PROFIT_STOP_ORDER",
            QuikStopOrderKind.TakeProfitAndStopLimitOrder => "TAKE_PROFIT_AND_STOP_LIMIT_ORDER",
            QuikStopOrderKind.ActivatedByOrderSimpleStopOrder => "ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER",
            QuikStopOrderKind.ActivatedByOrderTakeProfitStopOrder => "ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER",
            QuikStopOrderKind.ActivatedByOrderTakeProfitAndStopLimitOrder => "ACTIVATED_BY_ORDER_TAKE_PROFIT_AND_STOP_LIMIT_ORDER",
            _ => throw new ArgumentOutOfRangeException(nameof(stopOrderKind), stopOrderKind, null)
        };

    public static string AsString(this QuikStopPriceCondition condition) =>
            condition switch
            {
                QuikStopPriceCondition.MoreOrEqual => ">=",
                QuikStopPriceCondition.LessOrEqual => "<=",
                _ => throw new ArgumentOutOfRangeException(nameof(condition), condition, null)
            };

    public static string AsString(this QuikTypeOrder typeOrder) =>
        typeOrder switch
        {
            QuikTypeOrder.Limit => "L",
            QuikTypeOrder.Market => "M",
            _ => throw new ArgumentOutOfRangeException(nameof(typeOrder), typeOrder, null)
        };

    public static string AsString(this QuikUnits units) =>
        units switch
        {
            QuikUnits.Percents => "PERCENTS",
            QuikUnits.PriceUnits => "PRICE_UNITS",
            _ => throw new ArgumentOutOfRangeException(nameof(units), units, null)
        };

    public static string AsString(this QuikYesNo yesNo) =>
        yesNo switch
        {
            QuikYesNo.Yes => "YES",
            QuikYesNo.No => "NO",
            _ => throw new ArgumentOutOfRangeException(nameof(yesNo), yesNo, null)
        };

    public static string AsString(this QuikAction? action) =>
        action.HasValue ? action.Value.AsString() : string.Empty;
    public static string AsString(this QuikExecutionCondition? executionCondition) =>
        executionCondition.HasValue ? executionCondition.Value.AsString() : string.Empty;
    public static string AsString(this QuikExpiryDate? expiryDate) =>
        expiryDate.HasValue ? expiryDate.Value.AsString() : string.Empty;
    public static string AsString(this QuikForAccount? forAccount) =>
        forAccount.HasValue ? forAccount.Value.AsString() : string.Empty;
    public static string AsString(this QuikOperation? operation) =>
        operation.HasValue ? operation.Value.AsString() : string.Empty;
    public static string AsString(this QuikStopOrderKind? stopOrderKind) =>
        stopOrderKind.HasValue ? stopOrderKind.Value.AsString() : string.Empty;
    public static string AsString(this QuikStopPriceCondition? condition) =>
        condition.HasValue ? condition.Value.AsString() : string.Empty;
    public static string AsString(this QuikTypeOrder? typeOrder) =>
        typeOrder.HasValue ? typeOrder.Value.AsString() : string.Empty;
    public static string AsString(this QuikUnits? units) =>
        units.HasValue ? units.Value.AsString() : string.Empty;
    public static string AsString(this QuikYesNo? yesNo) =>
        yesNo.HasValue ? yesNo.Value.AsString() : string.Empty;

}
