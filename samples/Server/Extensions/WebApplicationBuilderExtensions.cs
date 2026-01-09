using Shared.Extensions;

namespace Server.Extensions;

internal static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder, bool useWebAssembly)
    {
        builder.Services.AddAntiforgery();

        if (useWebAssembly)
        {
            builder.Services
                .AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();
        }
        else
        {
            builder.Services
                .AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddHubOptions(configure => configure.MaximumReceiveMessageSize = 5 * 1024 * 1024);
        }

        builder.Services.AddHttpClient();
        builder.Services.AddLocalization();

        builder.WebHost.UseStaticWebAssets();

        builder.Services.AddRenderModeProvider(useWebAssembly);
        builder.Services.AddGalleryOptions();

        return builder;
    }
}
