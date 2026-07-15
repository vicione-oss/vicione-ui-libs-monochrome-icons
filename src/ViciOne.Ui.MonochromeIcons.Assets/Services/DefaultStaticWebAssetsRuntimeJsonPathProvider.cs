using System.IO;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal sealed class DefaultStaticWebAssetsRuntimeJsonPathProvider<T> : IStaticWebAssetsRuntimeJsonPathProvider
    where T : class
{
    private readonly string _path = Path.GetDirectoryName(typeof(T).Assembly.Location) ?? string.Empty;

    public string GetPath()
        => _path;
}
