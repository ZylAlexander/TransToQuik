using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikTypeOrder
{
    [EnumMember(Value = "L")]
    Limit,
    [EnumMember(Value = "M")]
    Market
}
