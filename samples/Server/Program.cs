using Server;
using Server.Extensions;
using Shared;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot",
});

var useWebAssembly = builder.Configuration.GetValue<bool>("RenderWasm");

var app = builder.ConfigureServices(useWebAssembly).Build();

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

if (useWebAssembly)
{
    app.UseWebAssemblyDebugging();
    app.MapRazorComponents<App>()
        .AddInteractiveWebAssemblyRenderMode();
}
else
{
    app.MapRazorComponents<App>()
        .AddAdditionalAssemblies([typeof(Routes).Assembly])
        .AddInteractiveServerRenderMode();
}

await app.RunAsync();
