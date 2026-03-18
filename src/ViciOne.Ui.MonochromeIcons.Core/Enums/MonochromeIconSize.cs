namespace ViciOne.Ui.MonochromeIcons.Core.Enums;

/// <summary>
/// Defines icon sizes for the Monochrome Icon set.
/// </summary>
public readonly record struct MonochromeIconSize : ITypeSafeEnumImplementation<MonochromeIconSize>
{
    /// <summary>
    /// 16 x 16 pixel
    /// </summary>
    public static readonly MonochromeIconSize Small = new(nameof(Small));

    /// <summary>
    /// 18 x 18 pixel
    /// </summary>
    public static readonly MonochromeIconSize SmallPlus2 = new(nameof(SmallPlus2));

    /// <summary>
    /// 24 x 24 pixel
    /// </summary>
    public static readonly MonochromeIconSize SmallMedium = new(nameof(SmallMedium));

    /// <summary>
    /// 32 x 32 pixel
    /// </summary>
    public static readonly MonochromeIconSize Medium = new(nameof(Medium));

    /// <summary>
    /// 48 x 48 pixel
    /// </summary>
    public static readonly MonochromeIconSize MediumLarge = new(nameof(MediumLarge));

    /// <summary>
    /// 64 x 64 pixel
    /// </summary>
    public static readonly MonochromeIconSize Large = new(nameof(Large));

    private readonly string _name;

    internal MonochromeIconSize(string name)
        => _name = name;

    /// <inheritdoc/>
    public static MonochromeIconSize GetDefaultValue()
        => Small;

    /// <inheritdoc/>
    public string GetName()
        => _name;

    /// <inheritdoc cref="GetName"/>
    public override string ToString()
        => GetName();
}
