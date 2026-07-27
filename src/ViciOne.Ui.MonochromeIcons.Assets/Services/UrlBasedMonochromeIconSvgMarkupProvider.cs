using Microsoft.Extensions.Logging;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;

namespace ViciOne.Ui.MonochromeIcons.Assets.Services;

internal sealed partial class UrlBasedMonochromeIconSvgMarkupProvider(HttpClient httpClient,
    ILogger<UrlBasedMonochromeIconSvgMarkupProvider> logger)
        : IMonochromeIconSvgMarkupProvider
{
    public async Task<string?> GetSvgMarkupAsync(MonochromeIconName iconName, MonochromeIconSize iconSize,
        CancellationToken cancellationToken = default)
    {
        // Build RCL static web assets URL starting with _content/...
        var assemblyName = typeof(UrlBasedMonochromeIconSvgMarkupProvider).Assembly.GetName().Name;
        var relativeUrl = $"_content/{assemblyName}";

        var url = $"{relativeUrl}/{iconSize.ToFolder()}/{iconName.ToString().ToDashCase()}.svg";

        try
        {
            var baseUri = httpClient.BaseAddress;
            if (baseUri is null)
                return null;

            var requestUri = new Uri(baseUri, url);

            using var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // Nothing to do here, return gracefully
        }
        catch (HttpRequestException ex)
        {
            HttpRequestExceptionOccurred(logger, ex);
        }

        return null;
    }

    public string? GetSvgMarkup(MonochromeIconName iconName, MonochromeIconSize iconSize)
        => throw new NotSupportedException("Synchronous SVG markup retrieval is not supported by the URL-based provider. Use " + nameof(GetSvgMarkupAsync) + " instead.");

    [LoggerMessage(Level = LogLevel.Error, Message = "An HTTP request exception occurred.")]
    private static partial void HttpRequestExceptionOccurred(ILogger logger, HttpRequestException ex);
}
