using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikStopPriceCondition
{
    [EnumMember(Value = ">=")]
    MoreOrEqual,
    [EnumMember(Value = "<=")]
    LessOrEqual
}
