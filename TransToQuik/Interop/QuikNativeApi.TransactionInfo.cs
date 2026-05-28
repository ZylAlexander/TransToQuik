using System;
using System.Runtime.InteropServices;

namespace TransToQuik.Interop;

internal static partial class QuikNativeApi
{
    /// <summary>
    /// возвращает код класса, по которому подана транзакция;
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_CLASS_CODE")]
    public static partial IntPtr ClassCode(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает код инструмента, по которому выставлена транзакция; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_SEC_CODE")]
    public static partial IntPtr SecCode(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает цену сделки; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_PRICE")]
    public static partial double Price(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает количество; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_QUANTITY")]
    public static partial long Quantity(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает остаток; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_BALANCE")]
    public static partial long Balance(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает код фирмы; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_FIRMID")]
    public static partial IntPtr FirmId(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает торговый счет; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_ACCOUNT")]
    public static partial IntPtr Account(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает код клиента; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_CLIENT_CODE")]
    public static partial IntPtr ClientCode(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает комментарий; 
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_BROKERREF")]
    public static partial IntPtr BrokerRef(IntPtr replyDescriptor);
    /// <summary>
    ///  возвращает биржевой номер заявки
    /// </summary>
    /// <param name="ReplyDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_EXCHANGE_CODE")]
    public static partial IntPtr ExchangeCode(IntPtr replyDescriptor);

    /// <summary>
    /// возвращает количество заявок;
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_ORDERS_COUNT")]
    public static partial short TransactionReplyOrdersCount(IntPtr tradeDescriptor);
    /// <summary>
    /// возвращает исходный номер заявки; EntityNumber
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_FIRST_ORDER_NUMBER_BY_ID")]
    public static partial int TransactionReplyFirstOrderNumberById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает номер заявки; EntityNumber
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_ORDER_NUMBER_BY_ID")]
    public static partial int TransactionReplyOrderNumberById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает цену;
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_PRICE_BY_ID")]
    public static partial double TransactionReplyPriceById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает количество; Quantity
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_QUANTITY_BY_ID")]
    public static partial long TransactionReplyQuantityById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает остаток; Quantity
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_BALANCE_BY_ID")]
    public static partial long TransactionReplyBalanceById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает код фирмы;
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_FIRMID_BY_ID")]
    public static partial IntPtr TransactionReplyFirmidById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает торговый счет;
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_ACCOUNT_BY_ID")]
    public static partial IntPtr TransactionReplyAccountById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает код клиента;
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_CLIENT_CODE_BY_ID")]
    public static partial IntPtr TransactionReplyClientCodeById(IntPtr tradeDescriptor, int orderId);
    /// <summary>
    /// возвращает комментарий
    /// </summary>
    /// <param name="tradeDescriptor"></param>
    /// <returns></returns>
    [LibraryImport(QuikNativeLibrary.Name, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_BROKERREF_BY_ID")]
    public static partial IntPtr TransactionReplyBrokerrefById(IntPtr tradeDescriptor, int orderId);

}

