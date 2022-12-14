namespace ToolBX.DescriptiveEnums;

public static class EnumExtensions
{
    /// <summary>
    /// Returns the "Text" in the enum's [Description("Text")]
    /// </summary>
    public static string GetDescription<T>(this T? value) where T : struct, Enum
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return value.Value.GetDescription();
    }

    /// <summary>
    /// Returns the "Text" in the enum's [Description("Text")]
    /// </summary>
    public static string GetDescription<T>(this T value) where T : struct, Enum
    {
        var description = typeof(T).GetMember(value.ToString()).Single().GetCustomAttribute<DescriptionAttribute>(true);
        if (description == null) throw new Exception(string.Format(Exceptions.EnumDoesNotHaveDescription, $"{typeof(T).Name}.{value}"));
        return description.Value;
    }

    /// <summary>
    /// Returns the "Text" in the enum's [Description("Text")] or the result of enum.ToString() if it has no [Description] attribute on it
    /// </summary>
    public static string TryGetDescription<T>(this T? value) where T : struct, Enum
    {
        if (value == null) return string.Empty;
        return value.Value.TryGetDescription();
    }

    /// <summary>
    /// Returns the "Text" in the enum's [Description("Text")] or the result of enum.ToString() if it has no [Description] attribute on it
    /// </summary>
    public static string TryGetDescription<T>(this T value) where T : struct, Enum
    {
        try
        {
            return value.GetDescription();
        }
        catch
        {
            return value.ToString();
        }
    }
}