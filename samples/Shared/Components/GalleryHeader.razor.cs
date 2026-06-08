using Microsoft.AspNetCore.Components;
using Shared.Services;

namespace Shared.Components;

public sealed partial class GalleryHeader : ComponentBase
{
    [Inject] private GalleryFilter Filter { get; set; } = default!;
    [Inject] private GalleryOptions Options { get; set; } = default!;
}
