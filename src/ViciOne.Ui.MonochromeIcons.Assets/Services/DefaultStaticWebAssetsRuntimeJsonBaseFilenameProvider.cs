namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal sealed class DefaultStaticWebAssetsRuntimeJsonBaseFilenameProvider<T> : IStaticWebAssetsRuntimeJsonBaseFilenameProvider
    where T : class
{
    private readonly string _baseFilename = typeof(T).Assembly.GetName().Name ?? string.Empty;

    public string GetBaseFilename()
        => _baseFilename;
}
