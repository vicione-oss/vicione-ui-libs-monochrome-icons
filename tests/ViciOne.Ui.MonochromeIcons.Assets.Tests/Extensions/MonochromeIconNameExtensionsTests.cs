using AwesomeAssertions;
using ViciOne.Ui.MonochromeIcons.Assets.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Assets.Tests.Extensions;

public sealed class MonochromeIconNameExtensionsTests
{
    [Fact]
    public void Should_return_svg_path()
    {
        // Arrange
        const string ContentRoot = "foo";
        var iconName = MonochromeIconName.Container;
        var iconSize = MonochromeIconSize.Large;

        // Act
        var svgPath = iconName.GetSvgPath(ContentRoot, iconSize);

        // Assert
        var expectedSvgPath = Path.Combine(ContentRoot, iconSize.ToFolder(), $"{iconName.ToString().ToDashCase()}.svg");

        svgPath.Should().Be(expectedSvgPath);
    }
}
