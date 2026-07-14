namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

/// <summary>
/// Provides a mechanism to retrieve the root folder for static web assets JSON.
/// </summary>
public interface IStaticWebAssetsRuntimeJsonPathProvider
{
    /// <summary>
    /// Gets the folder that contains static web assets JSON.
    /// </summary>
    string GetPath();
}
