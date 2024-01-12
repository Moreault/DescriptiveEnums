namespace ToolBX.DescriptiveEnums;

public sealed class MissingDescriptionException<T> : Exception where T : struct, Enum
{
    public T Value { get; }

    public MissingDescriptionException(T value) : base(string.Format(Exceptions.EnumDoesNotHaveDescription, $"{typeof(T).Name}.{value}"))
    {
        Value = value;
    }
}