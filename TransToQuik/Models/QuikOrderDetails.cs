using System;

namespace TransToQuik.Models;

/// <summary>
/// Дополнительные поля заявки, снятые в потоке callback (дескриптор QUIK после callback недействителен).
/// </summary>
public readonly record struct QuikOrderDetails(
    long OrderQty,
    int OrderDate,
    int OrderTime,
    int OrderActivationTime,
    int OrderWithdrawTime,
    int OrderExpiry,
    double OrderAccruedInt,
    double OrderYield,
    string OrderUserId,
    int OrderUID,
    string OrderAccount,
    string OrderBrokerRef,
    string OrderClientCode,
    string OrderFirmId,
    long OrderVisibleQty,
    int OrderPeriod,
    DateTime OrderFileTime,
    DateTime OrderWithdrawFileTime,
    int OrderDatePlaced,
    int OrderTimePlaced,
    int OrderMicrosecondsPlaced,
    int OrderDateWithdrawn,
    int OrderTimeWithdrawn,
    int OrderMicrosecondsWithdrawn,
    int OrderValueEntryType,
    int OrderExtendedFlags,
    int OrderMinQty,
    int OrderExecType,
    double OrderAwgPrice,
    string OrderRejectReason)
{
    public static QuikOrderDetails Empty => default;
}
