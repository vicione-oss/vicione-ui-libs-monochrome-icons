namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

/// <summary>
/// Provides a mechanism to retrieve the root folder for static web assets.
/// </summary>
public interface IFileSystemBasedContentRootProvider
{
    /// <summary>
    /// Gets the folder that contains static web assets.
    /// </summary>
    string? GetContentRoot();
}
