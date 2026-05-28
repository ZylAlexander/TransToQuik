using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikExpiryDate
{
    [EnumMember(Value = "GTC")]
    Gtc,
    [EnumMember(Value = "TODAY")]
    Today
}
