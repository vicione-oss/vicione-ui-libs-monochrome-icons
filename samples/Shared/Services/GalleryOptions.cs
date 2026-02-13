using System;
using System.Runtime.CompilerServices;

namespace Shared.Services;

public sealed class GalleryOptions
{
    private bool _isIconOutlineActive;
    private bool _areIconsColored;

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
