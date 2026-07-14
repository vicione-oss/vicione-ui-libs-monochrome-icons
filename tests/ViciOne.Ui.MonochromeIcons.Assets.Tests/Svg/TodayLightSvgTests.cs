// auto-generated code

using System.Linq;
using System.Threading.Tasks;
using AwesomeAssertions;
using Svg;
using ViciOne.Ui.MonochromeIcons.Assets.Tests.Svg.Fixtures;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Factories;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Assets.Tests.Svg;

public sealed class TodayLightSvgTests : IClassFixture<SvgTestFixture>
{
    public static readonly TheoryData<string> IconSizes =
        [.. TypeSafeEnumFactory<MonochromeIconSize>.CreateAll().Select(i => i.GetName())];

    private readonly SvgTestFixture _fixture;

    public TodayLightSvgTests(SvgTestFixture fixture)
    {
        _fixture = fixture;
        _fixture.MonochromeIconName = MonochromeIconName.TodayLight;
    }

    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_not_have_dtd(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgMarkup = await _fixture.GetSvgMarkupAsync(iconSizeTyped);

        // start directly with svg tag without DTD as recommended in https://www.w3.org/TR/SVG11/intro.html#NamespaceAndDTDIdentifiers
        svgMarkup?.Should().StartWith("<svg ");
    }

    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_be_minified(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgMarkup = await _fixture.GetSvgMarkupAsync(iconSizeTyped);

        svgMarkup?.Should().NotContainAny("\n", "\r\n");
    }

    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_have_width_px(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        if (svgDocument is not null)
        {
            var expectedSizePx = iconSizeTyped.ToPixels();

            svgDocument.Width.Should().Be(new SvgUnit(SvgUnitType.Pixel, expectedSizePx));
        }
    }

    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_have_height_px(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        if (svgDocument is not null)
        {
            var expectedSizePx = iconSizeTyped.ToPixels();

            svgDocument.Height.Should().Be(new SvgUnit(SvgUnitType.Pixel, expectedSizePx));
        }
    }

    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_have_viewbox(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        if (svgDocument is not null)
        {
            var expectedSizePx = iconSizeTyped.ToPixels();

            svgDocument.ViewBox.Should().Be(new SvgViewBox(0, 0, expectedSizePx, expectedSizePx));
        }
    }

    // Version is deprecated, see https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/version
    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_not_have_version(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        svgDocument?.ContainsAttribute("version").Should().BeFalse();
    }

    // Targets optimization, not needed for displaying an icon
    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_not_have_title(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        svgDocument?.Children.GetSvgElementOf<SvgTitle>().Should().BeNull();
    }

    // Targets optimization, not needed for displaying an icon
    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_not_have_id_attribute(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        svgDocument?.Descendants().Should().AllSatisfy(x => x.ID.Should().BeNull());
    }

    // Fill is ignored due to CSS rule "backgroundColor: currentcolor"
    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_not_have_fill_attribute_when_exists(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        svgDocument?.Descendants().Should().AllSatisfy(x => x.Fill.Should().BeOneOf(SvgPaintServer.NotSet, null));
    }

    // Stroke is ignored due to CSS rule "backgroundColor: currentcolor"
    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_not_have_stoke_attribute_when_exists(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        svgDocument?.Descendants().Should().AllSatisfy(x => x.Stroke.Should().BeOneOf(SvgPaintServer.NotSet, null));
    }

    // Disallows anything that we did not define before
    [Theory, Trait("Category", "Local")]
    [MemberData(nameof(IconSizes))]
    public async Task Should_have_specific_elements_when_exists(string iconSize)
    {
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        var svgDocument = await _fixture.GetSvgDocumentAsync(iconSizeTyped);

        if (svgDocument is not null)
        {
            // Arrange, Act
            var descendants = svgDocument.Descendants().ToHashSet();

            var groups = descendants.OfType<SvgGroup>();
            var paths = descendants.OfType<SvgPath>();
            var polygons = descendants.OfType<SvgPolygon>();
            var rectangles = descendants.OfType<SvgRectangle>();
            var circles = descendants.OfType<SvgCircle>();

            // Assert
            descendants.Except(groups).Except(paths).Except(polygons).Except(rectangles).Except(circles).Count().Should().Be(0);
        }
    }
}
