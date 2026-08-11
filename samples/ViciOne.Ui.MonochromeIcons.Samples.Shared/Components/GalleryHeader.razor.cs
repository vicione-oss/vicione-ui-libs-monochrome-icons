using Microsoft.AspNetCore.Components;
using ViciOne.Ui.MonochromeIcons.Samples.Shared.Services;

namespace ViciOne.Ui.MonochromeIcons.Samples.Shared.Components;

public sealed partial class GalleryHeader : ComponentBase
{
    [Inject] private GalleryFilter Filter { get; set; } = default!;
    [Inject] private GalleryOptions Options { get; set; } = default!;
}
