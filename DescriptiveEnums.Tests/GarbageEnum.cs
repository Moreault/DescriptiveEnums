namespace DescriptiveEnums.Tests;

public enum GarbageEnum
{
    [ToolBX.DescriptiveEnums.Description("It's something")]
    Something,
    [ToolBX.DescriptiveEnums.Description("It's something else!")]
    SomethingElse,
    AnotherThing,
    [ToolBX.DescriptiveEnums.Description("It's the last thing")]
    OneFinalThing
}