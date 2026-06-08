using System;
using System.Runtime.CompilerServices;

namespace Shared.Services;

public sealed class GalleryOptions
{
    private bool _showOutline;
    private bool _colored;
    private bool _withText;

    public bool ShowOutline
    {
        get => _showOutline;
        set
        {
            if (value != _showOutline)
            {
                _showOutline = value;

                OnPropertyChanged();
            }
        }
    }

    public bool Colored
    {
        get => _colored;
        set
        {
            if (value != _colored)
            {
                _colored = value;

                OnPropertyChanged();
            }
        }
    }

    public bool WithText
    {
        get => _withText;
        set
        {
            if (value != _withText)
            {
                _withText = value;

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
