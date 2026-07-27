using ViciOne.Ui.MonochromeIcons.Assets.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

/// <summary>
/// A provider that retrieves monochrome icon SVG markup from the file system based on the content root path.
/// </summary>
internal sealed class FileSystemBasedMonochromeIconSvgMarkupProvider(IFileSystemBasedContentRootProvider contentRootProvider)
    : IMonochromeIconSvgMarkupProvider
{
    private readonly string? _contentRoot = contentRootProvider.GetContentRoot();

    /// <inheritdoc/>
    public async Task<string?> GetSvgMarkupAsync(MonochromeIconName iconName, MonochromeIconSize iconSize,
        CancellationToken cancellationToken = default)
    {
        var svgPath = GetSvgPath(iconName, iconSize);

        if (svgPath is null)
            return null;

        return await File.ReadAllTextAsync(svgPath, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public string? GetSvgMarkup(MonochromeIconName iconName, MonochromeIconSize iconSize)
    {
        var svgPath = GetSvgPath(iconName, iconSize);

        if (svgPath is null)
            return null;

        return File.ReadAllText(svgPath);
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
