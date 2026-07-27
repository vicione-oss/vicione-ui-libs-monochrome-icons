using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Core.Extensions;

/// <summary>
/// Extension methods for <see cref="MonochromeIconSize"/>
/// </summary>
public static class MonochromeIconSizeExtensions
{
    private static readonly Dictionary<MonochromeIconSize, int> s_pixels = new()
    {
        { MonochromeIconSize.Tiny, 8 },
        { MonochromeIconSize.Small, 16 },
        { MonochromeIconSize.SmallPlus2, 18 },
        { MonochromeIconSize.SmallMedium, 24 },
        { MonochromeIconSize.Medium, 32 },
        { MonochromeIconSize.MediumLarge, 48 },
        { MonochromeIconSize.Large, 64 }
    };

    /// <summary>
    /// Converts <paramref name="size"/> to pixels
    /// </summary>
    public static int ToPixels(this MonochromeIconSize size)
        => s_pixels[size];

    /// <summary>
    /// Gets the modifier CSS class that implements the given <paramref name="size"/>, otherwise null.
    /// </summary>
    public static string? ToModifierCssClass(this MonochromeIconSize size)
    {
        if (size != MonochromeIconSize.Medium)
            return $"size-{size.ToPixels()}";
        else
            return null;
    }

    /// <summary>
    /// Gets the folder name for the given <paramref name="size"/>.
    /// </summary>
    public static string ToFolder(this MonochromeIconSize size)
    {
        var iconSizePx = size.ToPixels();

        return $"{iconSizePx}x{iconSizePx}";
    }
}
