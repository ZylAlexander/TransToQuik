using System.Runtime.Serialization;

namespace TransToQuik.Enums;

[DataContract]
public enum QuikYesNo
{
    [EnumMember(Value = "YES")]
    Yes,
    [EnumMember(Value = "NO")]
    No
}
