using System;
using TransToQuik.Interfaces;
using TransToQuik.Models;

namespace TransToQuik;

internal static class OrderDetailsSnapshotFactory
{
    public static QuikOrderDetails Capture(IQuikOrderInfoApi api, nint orderDescriptor)
    {
        if (orderDescriptor == nint.Zero)
        {
            return QuikOrderDetails.Empty;
        }

        return new QuikOrderDetails(
            api.OrderQty(orderDescriptor),
            api.OrderDate(orderDescriptor),
            api.OrderTime(orderDescriptor),
            api.OrderActivationTime(orderDescriptor),
            api.OrderWithdrawTime(orderDescriptor),
            api.OrderExpiry(orderDescriptor),
            api.OrderAccruedInt(orderDescriptor),
            api.OrderYield(orderDescriptor),
            api.OrderUserId(orderDescriptor),
            api.OrderUID(orderDescriptor),
            api.OrderAccount(orderDescriptor),
            api.OrderBrokerRef(orderDescriptor),
            api.OrderClientCode(orderDescriptor),
            api.OrderFirmId(orderDescriptor),
            api.OrderVisibleQTY(orderDescriptor),
            api.OrderPeriod(orderDescriptor),
            api.OrderFileTime(orderDescriptor),
            api.OrderWithdrawFileTime(orderDescriptor),
            api.OrderDateTime(orderDescriptor, 0),
            api.OrderDateTime(orderDescriptor, 1),
            api.OrderDateTime(orderDescriptor, 2),
            api.OrderDateTime(orderDescriptor, 3),
            api.OrderDateTime(orderDescriptor, 4),
            api.OrderDateTime(orderDescriptor, 5),
            api.OrderValueEntryType(orderDescriptor),
            api.OrderExtendedFlags(orderDescriptor),
            api.OrderMinQTY(orderDescriptor),
            api.OrderExecType(orderDescriptor),
            api.OrderAwgPrice(orderDescriptor),
            api.OrderRejectReason(orderDescriptor));
    }
}
