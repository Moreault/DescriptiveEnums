namespace ToolBX.DescriptiveEnums;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Struct)]
public class DescriptionAttribute : Attribute
{
    public string Value { get; }

    public DescriptionAttribute(string value)
    {
        Value = value;
    }
}