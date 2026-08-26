using System.Diagnostics.CodeAnalysis;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal interface IMonochromeIconSvgMarkupCache
{
    bool TryGet(MonochromeIconName iconName, MonochromeIconSize iconSize, [NotNullWhen(true)] out string? svgMarkup);

    string Add(MonochromeIconName iconName, MonochromeIconSize iconSize, string svgMarkup);
}
