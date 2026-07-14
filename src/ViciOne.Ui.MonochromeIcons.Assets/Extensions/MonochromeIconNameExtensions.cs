using System.IO;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;

namespace ViciOne.Ui.MonochromeIcons.Assets.Extensions;

internal static class MonochromeIconNameExtensions
{
    public static string GetSvgPath(this MonochromeIconName iconName, string contentRoot, MonochromeIconSize iconSize)
    {
        var path = Path.Combine(contentRoot, iconSize.ToFolder(), iconName.ToString().ToDashCase() + ".svg");

        return path;
    }
}
