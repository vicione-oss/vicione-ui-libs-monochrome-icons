using Microsoft.AspNetCore.Components;
using ViciOne.Ui.MonochromeIcons.Assets.Services;

namespace Shared.Layout;

public sealed partial class MainLayout : LayoutComponentBase
{
    private static string GetVersion()
    {
        var assembly = typeof(IMonochromeIconSvgMarkupProvider).Assembly;
        var assemblyName = assembly.GetName();
        var assemblyVersion = assemblyName.Version ?? throw new InvalidDataException();

        return $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
    }
}
