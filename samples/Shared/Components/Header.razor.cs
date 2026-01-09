using Microsoft.AspNetCore.Components;
using Shared.Models;
using Shared.Services;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace Shared.Components;

public sealed partial class Header : ComponentBase
{
    [Inject] private GalleryOptions GalleryOptions { get; set; } = default!;

    private void ClearFilter()
        => GalleryOptions.FilterText = null;

    private void SetIconSize(MonochromeIconSize newIconSize)
        => GalleryOptions.IconSize = newIconSize;

    private void SetIconStyle(IconStyle newIconStyle)
        => GalleryOptions.IconStyle = newIconStyle;
}
