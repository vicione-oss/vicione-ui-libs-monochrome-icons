using AwesomeAssertions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Core.Tests.Extensions;

public sealed class MonochromeIconNameExtensionsTests
{
    [Fact]
    public void Should_return_base_and_name_modifier_css_class()
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
    public void Should_return_size_modifier_css_class()
    {
        // Arrange
        var iconName = MonochromeIconName.Container;
        var iconSize = MonochromeIconSize.Large;

        // Act
        var cssClasses = iconName.GetCssClasses(iconSize);

        // Assert
        cssClasses.Should().Contain(iconSize.ToModifierCssClass());
    }
}
