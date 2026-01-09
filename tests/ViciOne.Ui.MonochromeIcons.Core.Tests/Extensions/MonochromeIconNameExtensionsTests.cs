using System.IO;
using AwesomeAssertions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Core.Tests.Extensions;

public sealed class MonochromeIconNameExtensionsTests
{
    [Fact]
    public void ShouldReturnBaseAndNameModifierCssClass()
    {
        // Arrange
        var iconName = MonochromeIconName.Container;

        // Act
        var cssClasses = iconName.GetCssClasses();

        // Assert
        cssClasses.Should().NotBeNull().And
            .HaveCount(2).And
            .Contain("monochrome-icon").And
            .Contain($"monochrome-icon-{iconName.ToString().ToDashCase()}");
    }

    [Fact]
    public void ShouldReturnSizeModifierCssClass()
    {
        // Arrange
        var iconName = MonochromeIconName.Container;
        var iconSize = MonochromeIconSize.Large;

        // Act
        var cssClasses = iconName.GetCssClasses(iconSize);

        // Assert
        cssClasses.Should().Contain(iconSize.ToModifierCssClass());
    }

    [Fact]
    public void ShouldReturnSvgPath()
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
