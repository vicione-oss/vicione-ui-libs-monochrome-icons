using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal sealed class MonochromeIconSvgMarkupCache : IMonochromeIconSvgMarkupCache
{
    private readonly ConcurrentDictionary<(MonochromeIconName Name, MonochromeIconSize Size), string> _markupByIcon = new();

    public bool TryGet(MonochromeIconName iconName, MonochromeIconSize iconSize, [NotNullWhen(true)] out string? svgMarkup)
        => _markupByIcon.TryGetValue((iconName, iconSize), out svgMarkup);

    public string Add(MonochromeIconName iconName, MonochromeIconSize iconSize, string svgMarkup)
        => _markupByIcon.GetOrAdd((iconName, iconSize), svgMarkup);
}
