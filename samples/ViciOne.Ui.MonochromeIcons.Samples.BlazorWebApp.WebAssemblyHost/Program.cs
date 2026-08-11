using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ViciOne.Ui.MonochromeIcons.Assets.Extensions;
using ViciOne.Ui.MonochromeIcons.Samples.Shared.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRenderModeProvider(true);
builder.Services.AddGalleryOptions();
builder.Services.AddUrlBasedMonochromeIconSvgMarkupProvider();

var host = builder.Build();

await host.RunAsync();
