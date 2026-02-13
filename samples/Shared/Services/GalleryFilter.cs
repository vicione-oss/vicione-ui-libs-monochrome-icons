using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Shared.Models;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace Shared.Services;

public sealed class GalleryFilter
{
    private string? _text;

    private readonly HashSet<MonochromeIconSize> _iconSizes = [];
    private readonly HashSet<IconStyle> _iconStyles = [];

    public IReadOnlySet<MonochromeIconSize> IconSizes => _iconSizes;
    public IReadOnlySet<IconStyle> IconStyles => _iconStyles;

    public string? Text
    {
        get => _text;
        set
        {
            if (value != _text)
            {
                _text = value;

                OnPropertyChanged();
            }
        }
    }

    public event Action<string>? Changed;

    public void Toggle(IconStyle iconStyle)
    {
        if (!_iconStyles.Remove(iconStyle))
            _iconStyles.Add(iconStyle);

        OnPropertyChanged(nameof(IconStyles));
    }

    public void Toggle(MonochromeIconSize iconSize)
    {
        if (!_iconSizes.Remove(iconSize))
            _iconSizes.Add(iconSize);

        OnPropertyChanged(nameof(IconSizes));
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (propertyName is null)
            return;

        Changed?.Invoke(propertyName);
    }
}
