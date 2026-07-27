using Microsoft.AspNetCore.Components;
using Shared.Models;
using Shared.Services;
using ViciOne.Ui.MonochromeIcons.Assets.Services;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Factories;

namespace Shared.Pages;

public sealed partial class Gallery : ComponentBase, IDisposable
{
    private readonly IReadOnlyCollection<MonochromeIconName> _allIcons = TypeSafeEnumFactory<MonochromeIconName>.CreateAll();
    private IReadOnlyCollection<MonochromeIconName> _currentIcons = [];
    private Dictionary<Tuple<MonochromeIconName, MonochromeIconSize>, MarkupString>? _svgMarkupCache;

    private readonly string _textBeforeIcon = "This item features an eye-catching icon ";
    private readonly string _textAfterIcon = " that immediately draws attention.";

    [Inject] private GalleryFilter Filter { get; set; } = default!;
    [Inject] private GalleryOptions Options { get; set; } = default!;
    [Inject] private IMonochromeIconSvgMarkupProvider MonochromeIconSvgMarkupProvider { get; set; } = default!;

    protected override void OnInitialized()
    {
        UpdateCurrentIcons();

        Filter.Changed += FilterChangedAsync;
        Options.Changed += OptionsChangedAsync;
    }

    protected override async Task OnInitializedAsync()
    {
        if (Options.UseSvgMarkup)
            await InitializeSvgMarkupCacheAsync();
    }

    public void Dispose()
    {
        Options.Changed -= OptionsChangedAsync;
        Filter.Changed -= FilterChangedAsync;
    }

    private async void FilterChangedAsync(string propertyName)
    {
        if (propertyName is nameof(Filter.Styles) or nameof(Filter.Sizes) or nameof(Filter.Text))
            UpdateCurrentIcons();

        await InvokeAsync(StateHasChanged);
    }

    private async void OptionsChangedAsync(string propertyName)
    {
        if (propertyName == nameof(GalleryOptions.UseSvgMarkup) && Options.UseSvgMarkup && _svgMarkupCache is null)
            await InitializeSvgMarkupCacheAsync();

        await InvokeAsync(StateHasChanged);
    }

    private void UpdateCurrentIcons()
    {
        IEnumerable<MonochromeIconName> icons = _allIcons;

        if (Filter.Styles.Count > 0)
            icons = icons.Where(icon => FilterIconStyles(icon, Filter.Styles));

        var filterText = Filter.Text?.Trim();
        if (!string.IsNullOrWhiteSpace(filterText))
        {
            icons = icons.Where(icon =>
            {
                var iconName = icon.GetName();

                return iconName.Contains(filterText, StringComparison.OrdinalIgnoreCase) ||
                    iconName.ToDashCase().Contains(filterText, StringComparison.OrdinalIgnoreCase);
            });
        }

        _currentIcons = [.. icons];
    }

    private static bool FilterIconStyles(MonochromeIconName icon, IReadOnlySet<IconStyle> iconStyles)
    {
        var iconName = icon.GetName();

        foreach (var iconStyle in iconStyles)
        {
            if (iconStyle == IconStyle.Light && iconName.Contains("light", StringComparison.OrdinalIgnoreCase))
                return true;

            if (iconStyle == IconStyle.Solid && iconName.Contains("solid", StringComparison.OrdinalIgnoreCase))
                return true;

            if (iconStyle == IconStyle.Unspecific
                && !iconName.Contains("light", StringComparison.OrdinalIgnoreCase)
                && !iconName.Contains("solid", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private async Task InitializeSvgMarkupCacheAsync()
    {
        IEnumerable<MonochromeIconSize> iconSizes = TypeSafeEnumFactory<MonochromeIconSize>.CreateAll();

        _svgMarkupCache = [];

        foreach (var icon in _currentIcons)
        {
            foreach (var size in iconSizes)
            {
                var svgMarkup = await MonochromeIconSvgMarkupProvider.GetSvgMarkupAsync(icon, size);
                if (svgMarkup != null)
                    _svgMarkupCache[new Tuple<MonochromeIconName, MonochromeIconSize>(icon, size)] = new MarkupString(svgMarkup);
            }
        }
    }
}
