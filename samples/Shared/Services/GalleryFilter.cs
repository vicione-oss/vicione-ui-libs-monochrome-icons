using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Shared.Models;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace Shared.Services;

public sealed class GalleryFilter
{
    private string? _text;

    private readonly HashSet<MonochromeIconSize> _sizes = [];
    private readonly HashSet<IconStyle> _styles = [];

    public IReadOnlySet<MonochromeIconSize> Sizes => _sizes;
    public IReadOnlySet<IconStyle> Styles => _styles;

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
        if (!_styles.Remove(iconStyle))
            _styles.Add(iconStyle);

        OnPropertyChanged(nameof(Styles));
    }

    public void Toggle(MonochromeIconSize iconSize)
    {
        if (!_sizes.Remove(iconSize))
            _sizes.Add(iconSize);

        OnPropertyChanged(nameof(Sizes));
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (propertyName is null)
            return;

        Changed?.Invoke(propertyName);
    }
}
