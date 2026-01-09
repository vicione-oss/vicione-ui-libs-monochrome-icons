using System.Collections.Generic;
using System.IO;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Core.Extensions;

/// <summary>
/// Extension methods for <see cref="MonochromeIconName"/>
/// </summary>
public static class MonochromeIconNameExtensions
{
    /// <summary>
    /// Get a list of CSS class names representing the icon specified by <paramref name="name"/> and optional <paramref name="size"/>.
    /// </summary>
    public static List<string> GetCssClasses(this MonochromeIconName name, MonochromeIconSize? size = null)
    {
        var cssClasses = new List<string> { "monochrome-icon", $"monochrome-icon-{name.ToString().ToDashCase()}" };

        var sizeModifierCssClass = size?.ToModifierCssClass();
        if (!string.IsNullOrWhiteSpace(sizeModifierCssClass))
            cssClasses.Add(sizeModifierCssClass);

        return cssClasses;
    }

    /// <summary>
    /// Gets the file path to the SVG icon for the given <paramref name="iconName"/> and <paramref name="iconSize"/>.
    /// </summary>
    public static string GetSvgPath(this MonochromeIconName iconName, string contentRoot, MonochromeIconSize iconSize)
    {
        var path = Path.Combine(contentRoot, iconSize.ToFolder(), iconName.ToString().ToDashCase() + ".svg");

        return path;
    }
}
