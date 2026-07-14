namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

/// <summary>
/// Provides a mechanism to retrieve the base filename of the static web assets runtime JSON file.
/// </summary>
public interface IStaticWebAssetsRuntimeJsonBaseFilenameProvider
{
    /// <summary>
    /// Gets the base filename of the static web assets runtime JSON file.
    /// </summary>
    string GetBaseFilename();
}
