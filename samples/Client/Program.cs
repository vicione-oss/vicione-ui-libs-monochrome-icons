using BlazorWasm.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.Extensions;
using ViciOne.Ui.MonochromeIcons.Assets.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRenderModeProvider(true);
builder.Services.AddGalleryOptions();
builder.Services.AddUrlBasedMonochromeIconSvgMarkupProvider();

var host = builder.Build();

await host.RunAsync();
