using System.Text;
using TransToQuik.Enums;
using TransToQuik.Extension;

namespace TransToQuik.Models.Transactions;

public abstract class QuikOrderTransaction : QuikTransaction
{
    /// <summary>
    /// Направление заявки, обязательный параметр. Значения: «S» – продать, «B» – купить 
    /// </summary>
    public required QuikOperation Operation { get; init; }

    /// <summary>
    /// Количество лотов в заявке, обязательный параметр  
    /// </summary>
    public required int Quantity { get; init; }

    /// <summary>
    /// Цена заявки, за единицу инструмента. Обязательный параметр. 
    /// При выставлении рыночной заявки (TYPE=M) на Срочном рынке FORTS необходимо указывать значение цены – укажите наихудшую (минимально или 
    /// максимально возможную – в зависимости от направленности), заявка все равно будет исполнена по рыночной цене. 
    /// Для других рынков при выставлении рыночной заявки укажите price=0.    
    /// </summary>
    public required double Price { get; init; }

    /// <summary>
    /// Тип заявки, необязательный параметр. Значения: «L» – лимитированная (по умолчанию), «M» – рыночная 
    /// </summary>
    public QuikTypeOrder? Type { get; init; }

    /// <summary>
    /// Условие исполнения заявки, необязательный параметр. Возможные значения: QuikExecutionCondition
    /// По умолчанию: PUT_IN_QUEUE
    /// </summary>
    public QuikExecutionCondition? ExecutionCondition { get; init; }

    protected override void AppendBody(StringBuilder sb)
    {
        sb.AppendIfNotEmpty("OPERATION", Operation.AsString());
        sb.AppendIfNotEmpty("QUANTITY", Quantity.ToString());
        sb.AppendIfNotEmpty("PRICE", Price.AsQuikPriceString(PriceScale));
        sb.AppendIfNotEmpty("TYPE", Type.AsString());
        sb.AppendIfNotEmpty("EXECUTION_CONDITION", ExecutionCondition?.AsString());
    }
    protected override ValidationResult ValidateSelf()
    {
        if (Quantity <= 0)
        {
            return ValidationResult.Failure("QuikOrder: Quantity must be greater than zero");
        }

        if (Price < 0)
        {
            return ValidationResult.Failure("QuikOrder: Price cannot be negative");
        }

        if (Type == QuikTypeOrder.Limit && Price == 0)
        {
            return ValidationResult.Failure("QuikOrder: Price must be greater than zero for limit orders (TYPE=L)");
        }

        return ValidationResult.Success();
    }
}
