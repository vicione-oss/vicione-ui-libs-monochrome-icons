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

public sealed partial class Index : ComponentBase, IDisposable
{
    private readonly IReadOnlyCollection<MonochromeIconName> _allIcons = TypeSafeEnumFactory<MonochromeIconName>.CreateAll();
    private IReadOnlyCollection<MonochromeIconName> _currentIcons = [];

    [Inject] private GalleryOptions GalleryOptions { get; set; } = default!;

    protected override void OnInitialized()
    {
        UpdateCurrentIcons();

        GalleryOptions.Changed += GalleryOptionsChangedAsync;
    }

    public void Dispose()
        => GalleryOptions.Changed -= GalleryOptionsChangedAsync;

    private async void GalleryOptionsChangedAsync(string propertyName)
    {
        if (propertyName is (nameof(GalleryOptions.IconStyle)) or (nameof(GalleryOptions.FilterText)))
            UpdateCurrentIcons();

        await InvokeAsync(StateHasChanged);
    }

    private void UpdateCurrentIcons()
    {
        if (string.IsNullOrWhiteSpace(GalleryOptions.FilterText))
        {
            _currentIcons = GetIconsForCurrentStyle();

            return;
        }

        var filterText = GalleryOptions.FilterText.Trim();

        _currentIcons =
        [
            .. GetIconsForCurrentStyle().Where(i =>
            {
                var iconName = i.GetName();

                return iconName.Contains(filterText, StringComparison.OrdinalIgnoreCase) ||
                    iconName.ToDashCase().Contains(filterText, StringComparison.OrdinalIgnoreCase);
            })
        ];
    }

    private IReadOnlyCollection<MonochromeIconName> GetIconsForCurrentStyle()
        => GalleryOptions.IconStyle switch
        {
            IconStyle.Light => [.. _allIcons.Where(i => i.GetName().Contains("light", StringComparison.OrdinalIgnoreCase))],
            IconStyle.Solid => [.. _allIcons.Where(i => i.GetName().Contains("solid", StringComparison.OrdinalIgnoreCase))],
            _ => [.. _allIcons.Where(i => !i.GetName().Contains("light", StringComparison.OrdinalIgnoreCase) && !i.GetName().Contains("solid", StringComparison.OrdinalIgnoreCase))],
        };
}
