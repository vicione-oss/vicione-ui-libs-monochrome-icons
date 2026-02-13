using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddGalleryOptions(this IServiceCollection services)
    {
        services.AddScoped<GalleryFilter>();
        services.AddScoped<GalleryOptions>();

        return services;
    }

    public static IServiceCollection AddRenderModeProvider(this IServiceCollection services, bool useWasm)
    {
        services.AddSingleton(new RenderModeProvider(useWasm));

        return services;
    }
}
