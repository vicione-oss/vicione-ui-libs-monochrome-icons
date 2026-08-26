using ViciOne.Ui.MonochromeIcons.Assets.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

/// <summary>
/// A provider that retrieves monochrome icon SVG markup from the file system based on the content root path.
/// </summary>
internal sealed class FileSystemBasedMonochromeIconSvgMarkupProvider(
    IFileSystemBasedContentRootProvider contentRootProvider, IMonochromeIconSvgMarkupCache svgMarkupCache) : IMonochromeIconSvgMarkupProvider
{
    private readonly string? _contentRoot = contentRootProvider.GetContentRoot();

    /// <inheritdoc/>
    public async Task<string?> GetSvgMarkupAsync(MonochromeIconName iconName, MonochromeIconSize iconSize,
        CancellationToken cancellationToken = default)
    {
        if (svgMarkupCache.TryGet(iconName, iconSize, out var svgMarkup))
            return svgMarkup;

        var svgPath = GetSvgPath(iconName, iconSize);

        if (svgPath is null)
            return null;

        svgMarkup = await File.ReadAllTextAsync(svgPath, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrEmpty(svgMarkup))
            return null;

        return svgMarkupCache.Add(iconName, iconSize, svgMarkup);
    }

    /// <inheritdoc/>
    public string? GetSvgMarkup(MonochromeIconName iconName, MonochromeIconSize iconSize)
    {
        if (svgMarkupCache.TryGet(iconName, iconSize, out var svgMarkup))
            return svgMarkup;

        var svgPath = GetSvgPath(iconName, iconSize);

        if (svgPath is null)
            return null;

        svgMarkup = File.ReadAllText(svgPath);

        if (string.IsNullOrEmpty(svgMarkup))
            return null;

        return svgMarkupCache.Add(iconName, iconSize, svgMarkup);
    }

    private string? GetSvgPath(MonochromeIconName iconName, MonochromeIconSize iconSize)
    {
        if (_contentRoot is null)
            return null;

        var svgPath = iconName.GetSvgPath(_contentRoot, iconSize);

        if (File.Exists(svgPath))
            return svgPath;

        return null;
    }
}
