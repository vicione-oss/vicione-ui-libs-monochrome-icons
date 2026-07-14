using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using ViciOne.Ui.MonochromeIcons.Assets.Models;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal sealed partial class StaticWebAssetsRuntimeJsonContentRootProvider(
    IStaticWebAssetsRuntimeJsonPathProvider pathProvider, IStaticWebAssetsRuntimeJsonBaseFilenameProvider filenameProvider,
    ILogger<StaticWebAssetsRuntimeJsonContentRootProvider>? logger = null) : IFileSystemBasedContentRootProvider
{
    public string? GetContentRoot()
    {
        var path = pathProvider.GetPath();
        var baseFilename = filenameProvider.GetBaseFilename();

        var staticWebAssetsRuntimeJsonFile = Path.Combine(path, $"{baseFilename}.staticwebassets.runtime.json");

        var contentRoot = GetContentRoot(staticWebAssetsRuntimeJsonFile);

        return contentRoot;
    }

    private string? GetContentRoot(string? staticWebAssetsRuntimeJsonFile)
    {
        if (!File.Exists(staticWebAssetsRuntimeJsonFile))
            return null;

        var json = File.ReadAllText(staticWebAssetsRuntimeJsonFile);

        var staticWebAssetsRuntime = JsonSerializer.Deserialize<StaticWebAssetsRuntime>(json);
        if (staticWebAssetsRuntime is null)
            return null;

        var contentRoot = staticWebAssetsRuntime.ContentRoots.FirstOrDefault(c =>
            c.Contains("\\vicione.ui.monochromeicons.assets\\", StringComparison.Ordinal) ||
            c.Contains("\\ViciOne.Ui.MonochromeIcons.Assets\\", StringComparison.Ordinal));

        if (logger is not null)
        {
            LogStaticWebAssetsRuntimeJson(logger, staticWebAssetsRuntimeJsonFile);
            LogContentRoot(logger, contentRoot);
        }

        return contentRoot;
    }

    [LoggerMessage(Level = LogLevel.Debug, Message = "Static web assets runtime JSON file is '{staticWebAssetsRuntimeJsonFile}'")]
    private static partial void LogStaticWebAssetsRuntimeJson(ILogger logger, string? staticWebAssetsRuntimeJsonFile);

    [LoggerMessage(Level = LogLevel.Debug, Message = "Content root is '{contentRoot}'")]
    private static partial void LogContentRoot(ILogger logger, string? contentRoot);
}
