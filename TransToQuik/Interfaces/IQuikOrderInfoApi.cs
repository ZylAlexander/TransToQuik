using System;

namespace TransToQuik.Interfaces;

public interface IQuikOrderInfoApi
{
    long OrderQty(IntPtr orderDescriptor);
    int OrderDate(IntPtr orderDescriptor);
    int OrderTime(IntPtr orderDescriptor);
    int OrderActivationTime(IntPtr orderDescriptor);
    int OrderWithdrawTime(IntPtr orderDescriptor);
    int OrderExpiry(IntPtr orderDescriptor);
    double OrderAccruedInt(IntPtr orderDescriptor);
    double OrderYield(IntPtr orderDescriptor);
    string OrderUserId(IntPtr orderDescriptor);
    int OrderUID(IntPtr orderDescriptor);
    string OrderAccount(IntPtr orderDescriptor);
    string OrderBrokerRef(IntPtr orderDescriptor);
    string OrderClientCode(IntPtr orderDescriptor);
    string OrderFirmId(IntPtr orderDescriptor);
    long OrderVisibleQTY(IntPtr orderDescriptor);
    int OrderPeriod(IntPtr orderDescriptor);
    DateTime OrderFileTime(IntPtr orderDescriptor);
    DateTime OrderWithdrawFileTime(IntPtr orderDescriptor);
    int OrderDateTime(IntPtr orderDescriptor, int timeType);
    int OrderValueEntryType(IntPtr orderDescriptor);
    int OrderExtendedFlags(IntPtr orderDescriptor);
    int OrderMinQTY(IntPtr orderDescriptor);
    int OrderExecType(IntPtr orderDescriptor);
    double OrderAwgPrice(IntPtr orderDescriptor);
    string OrderRejectReason(IntPtr orderDescriptor);
}
