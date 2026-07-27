using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

/// <summary>
/// Provider for monochrome icon SVG markup.
/// </summary>
public interface IMonochromeIconSvgMarkupProvider
{
    /// <summary>
    /// Gets the SVG markup for the specified icon name and size asynchronously.
    /// </summary>
    /// <param name="iconName">The name of the monochrome icon.</param>
    /// <param name="iconSize">The size of the monochrome icon.</param>
    /// <param name="cancellationToken">An optional token to cancel the operation.</param>
    /// <returns>The SVG markup as a string if found; otherwise <see langword="null"/>.</returns>
    Task<string?> GetSvgMarkupAsync(MonochromeIconName iconName, MonochromeIconSize iconSize,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the SVG markup for the specified icon name and size synchronously.
    /// </summary>
    /// <param name="iconName">The name of the monochrome icon.</param>
    /// <param name="iconSize">The size of the monochrome icon.</param>
    /// <returns>The SVG markup as a string if found; otherwise <see langword="null"/>.</returns>
    string? GetSvgMarkup(MonochromeIconName iconName, MonochromeIconSize iconSize);
}
