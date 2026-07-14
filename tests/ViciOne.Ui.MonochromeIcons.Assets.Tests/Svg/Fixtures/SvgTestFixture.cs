using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Svg;
using ViciOne.Ui.MonochromeIcons.Assets.Extensions;
using ViciOne.Ui.MonochromeIcons.Assets.Services;
using ViciOne.Ui.MonochromeIcons.Assets.Tests.Svg.Extensions;
using ViciOne.Ui.MonochromeIcons.Assets.Tests.Svg.Services;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace ViciOne.Ui.MonochromeIcons.Assets.Tests.Svg.Fixtures;

#pragma warning disable CA1515 // Consider making public types internal

public sealed class SvgTestFixture : IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceScope _serviceScope;
    private readonly IMonochromeIconSvgMarkupProvider _svgMarkupProvider;

    private readonly Dictionary<MonochromeIconSize, string> _svgMarkups = [];
    private readonly Dictionary<MonochromeIconSize, SvgDocument> _svgDocuments = [];

    public IReadOnlyDictionary<MonochromeIconSize, string> SvgMarkups => _svgMarkups;
    public IReadOnlyDictionary<MonochromeIconSize, SvgDocument> SvgDocuments => _svgDocuments;

    public MonochromeIconName MonochromeIconName { get; set; }

    public SvgTestFixture()
    {
        var serviceCollection = new ServiceCollection()
            .AddStaticWebAssetsRuntimeJsonPathProvider<StaticWebAssetsRuntimeJsonPathProvider>()
            .AddFileSystemBasedMonochromeIconSvgMarkupProvider();

        _serviceProvider = serviceCollection.BuildServiceProvider();
        _serviceScope = _serviceProvider.CreateScope();

        _svgMarkupProvider = _serviceScope.ServiceProvider.GetRequiredService<IMonochromeIconSvgMarkupProvider>();
    }

    public void Dispose()
    {
        _serviceScope?.Dispose();

        if (_serviceProvider is IDisposable disposableServiceProvider)
            disposableServiceProvider.Dispose();
    }

    public async Task<SvgDocument?> GetSvgDocumentAsync(MonochromeIconSize iconSize)
    {
        if (_svgDocuments.TryGetValue(iconSize, out var svgDocument))
        {
            return svgDocument;
        }
        else
        {
            var svgMarkup = await _svgMarkupProvider.GetSvgMarkupAsync(MonochromeIconName, iconSize);

            if (!string.IsNullOrEmpty(svgMarkup))
            {
                _svgMarkups[iconSize] = svgMarkup;

                svgDocument = svgMarkup.ToSvgDocument();

                _svgDocuments[iconSize] = svgDocument;

                return svgDocument;
            }
            else
            {
                // no markup returned, this means that the icon with the requested size
                // does not exist, in this case we simply let the tests run green because
                // the tests for size 32 take precedence as size 32 is the fallback size

                return null;
            }
        }
    }

    public async Task<string?> GetSvgMarkupAsync(MonochromeIconSize iconSize)
    {
        if (_svgMarkups.TryGetValue(iconSize, out var svgMarkup))
        {
            return svgMarkup;
        }
        else
        {
            svgMarkup = await _svgMarkupProvider.GetSvgMarkupAsync(MonochromeIconName, iconSize);

            if (!string.IsNullOrEmpty(svgMarkup))
            {
                _svgMarkups[iconSize] = svgMarkup;
                _svgDocuments[iconSize] = svgMarkup.ToSvgDocument();
            }
            else
            {
                // no markup returned, this means that the icon with the requested size
                // does not exist, in this case we simply let the tests run green because
                // the tests for size 32 take precedence as size 32 is the fallback size
            }

            return svgMarkup;
        }
    }
}

#pragma warning restore CA1515 // Consider making public types internal
