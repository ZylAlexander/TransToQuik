using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikExecutionCondition
{
    /// <summary>
    /// поставить в очередь(по умолчанию);
    /// </summary>
    [EnumMember(Value = "PUT_IN_QUEUE")]
    PutInQueue,
    /// <summary>
    /// немедленно или отклонить;
    /// </summary>
    [EnumMember(Value = "FILL_OR_KILL")]
    /// <summary>
    /// снять остаток
    /// </summary>
    FillOrKill,
    [EnumMember(Value = "KILL_BALANCE")]
    KillBalance
}




