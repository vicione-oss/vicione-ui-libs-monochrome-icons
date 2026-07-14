using System.IO;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal sealed class DefaultStaticWebAssetsRuntimeJsonPathProvider : IStaticWebAssetsRuntimeJsonPathProvider
{
    private readonly string _path =
        Path.GetDirectoryName(typeof(DefaultStaticWebAssetsRuntimeJsonPathProvider).Assembly.Location) ?? string.Empty;

    public string GetPath()
        => _path;
}
