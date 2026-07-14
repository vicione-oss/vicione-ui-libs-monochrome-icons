namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal sealed class DefaultStaticWebAssetsRuntimeJsonBaseFilenameProvider : IStaticWebAssetsRuntimeJsonBaseFilenameProvider
{
    private readonly string _baseFilename =
        typeof(DefaultStaticWebAssetsRuntimeJsonBaseFilenameProvider).Assembly.GetName().Name ?? string.Empty;

    public string GetBaseFilename()
        => _baseFilename;
}
