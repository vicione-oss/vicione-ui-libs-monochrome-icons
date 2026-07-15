using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ViciOne.Ui.MonochromeIcons.Assets.Models;
using ViciOne.Ui.MonochromeIcons.Assets.Services;

namespace ViciOne.Ui.MonochromeIcons.Assets.Extensions;

/// <summary>
/// Extension methods for registering monochrome icon SVG markup providers.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds a URL-based SVG markup provider for monochrome icons.
    /// </summary>
    /// <remarks>
    /// The provider relies on <c>_content/...</c> URLs for fetching SVG files via HTTP client.
    /// The provider is registered by using <c>TryAddScoped</c>, so an existing
    /// <see cref="IMonochromeIconSvgMarkupProvider"/> registration is preserved.
    /// </remarks>
    public static IServiceCollection AddUrlBasedMonochromeIconSvgMarkupProvider(this IServiceCollection services)
    {
        services.AddLogging();

        services.TryAddScoped<IMonochromeIconSvgMarkupProvider, UrlBasedMonochromeIconSvgMarkupProvider>();

        return services;
    }

    /// <inheritdoc cref="AddFileSystemBasedMonochromeIconSvgMarkupProvider(IServiceCollection)"/>
    /// <typeparam name="T">The type used to determine the assembly location for locating <c>staticwebassets.runtime.json</c> files.</typeparam>
    public static IServiceCollection AddFileSystemBasedMonochromeIconSvgMarkupProvider<T>(this IServiceCollection services)
        where T : class
    {
        services.AddLogging();

        services.AddStaticWebAssetsRuntimeJsonPathProvider<DefaultStaticWebAssetsRuntimeJsonPathProvider<T>>();
        services.AddStaticWebAssetsRuntimeJsonBaseFilenameProvider<DefaultStaticWebAssetsRuntimeJsonBaseFilenameProvider<T>>();

        services.AddFileSystemBasedContentRootProvider<StaticWebAssetsRuntimeJsonContentRootProvider>();

        services.TryAddSingleton<IMonochromeIconSvgMarkupProvider, FileSystemBasedMonochromeIconSvgMarkupProvider>();

        return services;
    }

    /// <summary>
    /// Adds a file system-based SVG markup provider for monochrome icons.
    /// </summary>
    /// <remarks>
    /// The provider relies on <c>staticwebassets.runtime.json</c> files for locating SVG files.
    /// The provider is registered by using <c>TryAddSingleton</c>, so existing
    /// <see cref="IMonochromeIconSvgMarkupProvider"/> registrations are preserved.
    /// </remarks>
    public static IServiceCollection AddFileSystemBasedMonochromeIconSvgMarkupProvider(this IServiceCollection services)
        => services.AddFileSystemBasedMonochromeIconSvgMarkupProvider<StaticWebAssetsRuntime>();

    /// <summary>
    /// Adds a custom implementation of <see cref="IStaticWebAssetsRuntimeJsonBaseFilenameProvider"/> to the service collection.
    /// </summary>
    public static IServiceCollection AddStaticWebAssetsRuntimeJsonBaseFilenameProvider<T>(this IServiceCollection services)
        where T : class, IStaticWebAssetsRuntimeJsonBaseFilenameProvider
    {
        services.TryAddSingleton<IStaticWebAssetsRuntimeJsonBaseFilenameProvider, T>();

        return services;
    }

    /// <summary>
    /// Adds a custom implementation of <see cref="IStaticWebAssetsRuntimeJsonPathProvider"/> to the service collection.
    /// </summary>
    public static IServiceCollection AddStaticWebAssetsRuntimeJsonPathProvider<T>(this IServiceCollection services)
        where T : class, IStaticWebAssetsRuntimeJsonPathProvider
    {
        services.TryAddSingleton<IStaticWebAssetsRuntimeJsonPathProvider, T>();

        return services;
    }

    /// <summary>
    /// Adds a custom implementation of <see cref="IFileSystemBasedContentRootProvider"/> to the service collection.
    /// </summary>
    public static IServiceCollection AddFileSystemBasedContentRootProvider<T>(this IServiceCollection services)
        where T : class, IFileSystemBasedContentRootProvider
    {
        services.TryAddSingleton<IFileSystemBasedContentRootProvider, T>();

        return services;
    }
}
