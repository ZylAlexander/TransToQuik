using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions;

public abstract class QuikTransaction
{
    private const int _transactionsLenght = 256;
    private static int _transactionId;
    private static int GetTransactionId()
    {
        while (true)
        {
            var next = Interlocked.Increment(ref _transactionId);

            if (next <= 0)
            {

                if (Interlocked.CompareExchange(ref _transactionId, 1, next) == next)
                {
                    return 1;
                }
                continue;
            }

            return next;
        }
    }  

    private readonly int _transId = GetTransactionId();
    /// <summary>
    /// Код класса, по которому выполняется транзакция, например TQBR. 
    /// Обязательный параметр  
    /// </summary>
    public required string ClassCode { get; init; }

    /// <summary>
    /// Номер счета Трейдера. Параметр обязателен при «ACTION» = «KILL_ALL_FUTURES_ORDERS». Параметр чувствителен к верхнему/нижнему регистру символов.          
    /// </summary>
    public required string Account { get; init; }

    /// <summary>
    /// Код инструмента, по которому выполняется транзакция, например SBER 
    /// </summary>
    public string SecCode { get; init; }

    /// <summary>
    /// 20-ти символьное составное поле, может содержать код клиента и текстовый комментарий (поручение) с тем же разделителем, что и при вводе заявки вручную. Необязательный параметр 
    /// </summary>
    public string ClientCode { get; init; }

    /// <summary>
    /// Признак того, является ли заявка заявкой Маркет-Мейкера. Возможные значения: «YES» или «NO». Значение по умолчанию (если параметротсутствует): «NO»
    /// </summary>
    public QuikYesNo? MarketMakerOrder { get; init; }

    /// <summary>
    /// Идентификатор фирмы, к которой относится заявка. Необязательный параметр.
    /// </summary>
    public string FirmId { get; init; }

    /// <summary>
    /// Текстовый комментарий, указанный в заявке. Используется при снятии группы заявок
    /// </summary>
    public string Comment { get; init; }

    /// <summary>
    /// Точность цены инструмента: число знаков после десятичного разделителя в полях PRICE, STOPPRICE и т.п.
    /// Соответствует полю <c>scale</c> из <c>getSecurityInfo(class_code, sec_code)</c> в QLua
    /// (или параметру <c>SEC_SCALE</c>)
    /// </summary>
    public int? PriceScale { get; init; }

    /// <summary>
    /// Уникальный идентификационный номер заявки, значение от «1» до «2 147 483 647»  
    /// </summary>
    public int TransId => _transId;

    /// <summary>
    /// Вид транзакции, имеющий одно из следующих значений: QuikAction
    /// </summary>
    public abstract QuikAction Action { get; }

    public ValidationResult Validate()
    {
        var baseResult = ValidateBase();
        if (!baseResult.IsValid)
            return baseResult;

        return ValidateSelf();
    }

    public string ToQuikString()
    {
        var sb = new StringBuilder(_transactionsLenght);
        AppendHeader(sb);
        AppendBody(sb);
        return sb.ToString();
    }
    public override string ToString() => ToQuikString();
    protected abstract void AppendBody(StringBuilder sb);
    protected abstract ValidationResult ValidateSelf();
    private void AppendHeader(StringBuilder sb)
    {
        sb.AppendIfNotEmpty("ACTION", Action.AsString());
        sb.AppendIfNotEmpty("TRANS_ID", _transId.ToString());
        sb.AppendIfNotEmpty("ACCOUNT", Account);
        sb.AppendIfNotEmpty("CLASSCODE", ClassCode);
        sb.AppendIfNotEmpty("SECCODE", SecCode);
        sb.AppendIfNotEmpty("CLIENT_CODE", ClientCode);
        sb.AppendIfNotEmpty("MARKET_MAKER_ORDER", MarketMakerOrder.AsString());
        sb.AppendIfNotEmpty("FIRM_ID", FirmId);
        sb.AppendIfNotEmpty("COMMENT", Comment);
    }
    private ValidationResult ValidateBase()
    {
        if (string.IsNullOrWhiteSpace(Account))
        {
            return ValidationResult.Failure("QuikTransaction: Account is required.");
        }

        if (Action is QuikAction.KillAllOrders or QuikAction.KillAllStopOrders or QuikAction.KillAllNegDeals)
        {
            return ValidationResult.Failure(
                $"QuikTransaction: Action {Action.AsString()} is not supported by Trans2QUIK.dll.");
        }

        if (Action == QuikAction.KillAllFuturesOrders)
        {
            return ValidationResult.Success();
        }

        if (string.IsNullOrWhiteSpace(ClassCode))
        {
            return ValidationResult.Failure("QuikTransaction: ClassCode is required.");
        }

        return ValidationResult.Success();
    }
}
