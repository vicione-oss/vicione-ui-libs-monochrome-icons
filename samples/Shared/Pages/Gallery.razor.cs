using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using Shared.Services;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Factories;

namespace Shared.Pages;

public sealed partial class Gallery : ComponentBase, IDisposable
{
    private readonly IReadOnlyCollection<MonochromeIconName> _allIcons = TypeSafeEnumFactory<MonochromeIconName>.CreateAll();
    private IReadOnlyCollection<MonochromeIconName> _currentIcons = [];

    [Inject] private GalleryFilter Filter { get; set; } = default!;
    [Inject] private GalleryOptions Options { get; set; } = default!;

    protected override void OnInitialized()
    {
        UpdateCurrentIcons();

        Filter.Changed += FilterChangedAsync;
        Options.Changed += OptionsChangedAsync;
    }

    public void Dispose()
    {
        Options.Changed -= OptionsChangedAsync;
        Filter.Changed -= FilterChangedAsync;
    }

    private async void FilterChangedAsync(string propertyName)
    {
        if (propertyName is nameof(Filter.IconStyles) or nameof(Filter.IconSizes) or nameof(Filter.Text))
            UpdateCurrentIcons();

        await InvokeAsync(StateHasChanged);
    }

    private async void OptionsChangedAsync(string propertyName)
        => await InvokeAsync(StateHasChanged);

    private void UpdateCurrentIcons()
    {
        IEnumerable<MonochromeIconName> icons = _allIcons;

        if (Filter.IconStyles.Count > 0)
            icons = icons.Where(icon => FilterIconStyles(icon, Filter.IconStyles));

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
}
