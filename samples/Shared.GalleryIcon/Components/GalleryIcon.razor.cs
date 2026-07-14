using Microsoft.AspNetCore.Components;
using ViciOne.Ui.MonochromeIcons.Core.Enums;

namespace Shared.GalleryIcon.Components;

public partial class GalleryIcon : ComponentBase
{
    [Parameter, EditorRequired]
    public required MonochromeIconName Name { get; set; }

    [Parameter]
    public MonochromeIconSize Size { get; set; } = MonochromeIconSize.Medium;
}
