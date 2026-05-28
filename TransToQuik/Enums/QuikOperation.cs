using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikOperation
{
    [EnumMember(Value = "B")]
    Buy,
    [EnumMember(Value = "S")]
    Sell
}
