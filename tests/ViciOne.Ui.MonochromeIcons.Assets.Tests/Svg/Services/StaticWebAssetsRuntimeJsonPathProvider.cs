using ViciOne.Ui.MonochromeIcons.Assets.Services;

namespace ViciOne.Ui.MonochromeIcons.Assets.Tests.Svg.Services;

internal sealed class StaticWebAssetsRuntimeJsonPathProvider : IStaticWebAssetsRuntimeJsonPathProvider
{
    public string GetPath()
        => AppContext.BaseDirectory;
}
