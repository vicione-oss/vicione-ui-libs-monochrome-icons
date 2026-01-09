using Microsoft.AspNetCore.Components;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;

namespace ViciOne.Ui.MonochromeIcons.Components;

/// <summary>
/// Component for rendering a monochrome icon
/// </summary>
public partial class MonochromeIcon : ComponentBase
{
    /// <summary>
    /// Name of the icon
    /// </summary>
    [Parameter, EditorRequired]
    public required MonochromeIconName Name { get; set; }

    /// <summary>
    /// Size of the icon, defaults to <see cref="MonochromeIconSize.Medium" />
    /// </summary>
    [Parameter]
    public MonochromeIconSize Size { get; set; } = MonochromeIconSize.Medium;

    /// <summary>
    /// Value for the class attribute
    /// </summary>
    [Parameter]
    public string? CssClass { get; set; }

    private string GetCssClasses()
    {
        var cssClasses = Name.GetCssClasses(Size);

        if (!string.IsNullOrWhiteSpace(CssClass))
            cssClasses.AddRange(CssClass.Split(" "));

        return cssClasses.ToSpaceSeparated();
    }
}
