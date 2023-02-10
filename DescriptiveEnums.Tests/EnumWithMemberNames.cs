namespace DescriptiveEnums.Tests;

public enum EnumWithMemberNames
{
    [ToolBX.DescriptiveEnums.Description("==")]
    Equals,
    [ToolBX.DescriptiveEnums.Description("Hash!")]
    GetHashcode,
    [ToolBX.DescriptiveEnums.Description("String!")]
    ToString
}