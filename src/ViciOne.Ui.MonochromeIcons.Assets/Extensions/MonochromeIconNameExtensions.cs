using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;

namespace ViciOne.Ui.MonochromeIcons.Assets.Extensions;

/// <summary>
/// Extension methods for <see cref="MonochromeIconName"/>
/// </summary>
public static class MonochromeIconNameExtensions
{
    /// <summary>
    /// <para>
    ///     Loads the SVG markup for the given <paramref name="iconName"/> and <paramref name="iconSize"/>
    ///     from the application's static web assets.
    /// </para>
    ///
    /// <para>
    ///     The lookup for static web assets searches all content roots listed in the runtime map and
    ///     expects files at <c>{contentRoot}/{size-folder}/{icon-name-in-dash-case}.svg</c>.
    /// </para>
    /// </summary>
    /// <param name="iconName">The logical name of the icon.</param>
    /// <param name="iconSize">The size variant to load (affects the size-specific folder).</param>
    /// <returns>The SVG markup as a string if found; otherwise <see langword="null"/>.</returns>
    public static string? GetSvgMarkup(this MonochromeIconName iconName, MonochromeIconSize iconSize)
    {
        var staticWebAssetsRuntimeJsonPath = GetStaticWebAssetsRuntimeJsonPath();
        if (staticWebAssetsRuntimeJsonPath is null)
            return null;

        var contentRoots = GetContentRoots(staticWebAssetsRuntimeJsonPath);

        foreach (var contentRoot in contentRoots)
        {
            var svgPath = iconName.GetSvgPath(contentRoot, iconSize);

            if (File.Exists(svgPath))
                return File.ReadAllText(svgPath);
        }

        return null;
    }

    private static string? GetStaticWebAssetsRuntimeJsonPath()
    {
        var assembly = typeof(MonochromeIconNameExtensions).Assembly;
        var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
        if (assemblyDirectory is null)
            return null;

        var staticWebAssetsRuntimeJsonPath = Path.Combine(assemblyDirectory,
            Path.GetFileNameWithoutExtension(assembly.Location) + ".staticwebassets.runtime.json");

        return staticWebAssetsRuntimeJsonPath;
    }

    private sealed class StaticWebAssetsRuntime
    {
        public IEnumerable<string> ContentRoots { get; set; } = [];
    }

    private static IEnumerable<string> GetContentRoots(string staticWebAssetsRuntimeJsonPath)
    {
        var json = File.ReadAllText(staticWebAssetsRuntimeJsonPath);

        var staticWebAssetsRuntime = JsonSerializer.Deserialize<StaticWebAssetsRuntime>(json);
        if (staticWebAssetsRuntime is not null)
            return staticWebAssetsRuntime.ContentRoots;
        else
            return [];
    }
}
