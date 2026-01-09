namespace ViciOne.Ui.MonochromeIcons.Core.Enums;

/// <summary>
/// Type-safe implementation of an enum represented by <typeparamref name="T"/>
/// </summary>
public interface ITypeSafeEnumImplementation<T>
{
    /// <summary>
    /// Gets the type-safe implementation of the default enum value.
    /// </summary>
    static abstract T GetDefaultValue();

    /// <summary>
    /// Gets the name of the enum value represented by the instance on which this method is called.
    /// </summary>
    string GetName();
}
