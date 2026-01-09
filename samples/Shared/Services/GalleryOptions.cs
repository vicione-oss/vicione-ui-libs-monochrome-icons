using System;
using System.Runtime.CompilerServices;
using Shared.Models;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace Shared.Services;

public sealed class GalleryOptions
{
    private IconStyle _iconStyle = IconStyle.Unspecific;
    private MonochromeIconSize _iconSize = MonochromeIconSize.Medium;
    private bool _isIconOutlineActive;
    private string? _filterText;
    private bool _areIconsColored;

    public IconStyle IconStyle
    {
        get => _iconStyle;
        set
        {
            if (value != _iconStyle)
            {
                _iconStyle = value;

                OnPropertyChanged();
            }
        }
    }

    public MonochromeIconSize IconSize
    {
        get => _iconSize;
        set
        {
            if (value != _iconSize)
            {
                _iconSize = value;

                OnPropertyChanged();
            }
        }
    }

    public bool IsIconOutlineActive
    {
        get => _isIconOutlineActive;
        set
        {
            if (value != _isIconOutlineActive)
            {
                _isIconOutlineActive = value;

                OnPropertyChanged();
            }
        }
    }

    public string? FilterText
    {
        get => _filterText;
        set
        {
            if (value != _filterText)
            {
                _filterText = value;

                OnPropertyChanged();
            }
        }
    }

    public bool AreIconsColored
    {
        get => _areIconsColored;
        set
        {
            if (value != _areIconsColored)
            {
                _areIconsColored = value;

                OnPropertyChanged();
            }
        }
    }

    public event Action<string>? Changed;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (propertyName is null)
            return;

        Changed?.Invoke(propertyName);
    }
}
