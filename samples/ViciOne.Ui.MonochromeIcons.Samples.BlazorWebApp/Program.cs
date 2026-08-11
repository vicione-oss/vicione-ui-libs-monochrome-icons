using ViciOne.Ui.MonochromeIcons.Samples.BlazorWebApp;
using ViciOne.Ui.MonochromeIcons.Samples.BlazorWebApp.Extensions;
using ViciOne.Ui.MonochromeIcons.Samples.Shared;
using ViciOne.Ui.MonochromeIcons.Assets.Extensions;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot",
});

var useWebAssembly = builder.Configuration.GetValue<bool>("RenderWasm");

if (useWebAssembly)
    builder.Services.AddUrlBasedMonochromeIconSvgMarkupProvider();
else
    builder.Services.AddFileSystemBasedMonochromeIconSvgMarkupProvider<Program>();

var app = builder.ConfigureServices(useWebAssembly).Build();

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

if (useWebAssembly)
{
    app.UseWebAssemblyDebugging();
    app.MapRazorComponents<App>()
        .AddAdditionalAssemblies([typeof(Routes).Assembly])
        .AddInteractiveWebAssemblyRenderMode();
}
else
{
    app.MapRazorComponents<App>()
        .AddAdditionalAssemblies([typeof(Routes).Assembly])
        .AddInteractiveServerRenderMode();
}

await app.RunAsync();
