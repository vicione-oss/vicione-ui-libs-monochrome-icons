using AwesomeAssertions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Factories;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Core.Tests.Extensions;

public sealed class MonochromeIconSizeExtensionsTests
{
    public static readonly TheoryData<string> IconSizes = [.. TypeSafeEnumFactory<MonochromeIconSize>.CreateAll().GetNames()];

    [Theory]
    [MemberData(nameof(IconSizes))]
    public void Assert_to_pixel_result(string iconSize)
    {
        // Arrange
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        // Act
        var pixels = iconSizeTyped.ToPixels();

        // Assert
        pixels.Should().BeGreaterThan(0);
    }

    [Fact]
    public void Assert_to_modifier_css_class_result()
    {
        // Arrange
        var iconSizes = TypeSafeEnumFactory<MonochromeIconSize>.CreateAll();

        foreach (var iconSize in iconSizes)
        {
            var expectedResult = iconSize != MonochromeIconSize.Medium ? $"size-{iconSize.ToPixels()}" : null;

            // Act
            var result = iconSize.ToModifierCssClass();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
