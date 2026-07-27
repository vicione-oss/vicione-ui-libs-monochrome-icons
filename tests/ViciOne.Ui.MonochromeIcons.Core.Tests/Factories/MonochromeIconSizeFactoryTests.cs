using AwesomeAssertions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Factories;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Core.Tests.Factories;

public class MonochromeIconSizeFactoryTests
{
    [Fact]
    public void Should_return_all_monochrome_icon_sizes()
    {
        // Arrange
        IReadOnlyCollection<MonochromeIconSize> expected =
        [
            MonochromeIconSize.Tiny,
            MonochromeIconSize.Small,
            MonochromeIconSize.SmallPlus2,
            MonochromeIconSize.SmallMedium,
            MonochromeIconSize.Medium,
            MonochromeIconSize.MediumLarge,
            MonochromeIconSize.Large,
        ];

        // Act
        var iconSizes = TypeSafeEnumFactory<MonochromeIconSize>.CreateAll();

        // Assert
        iconSizes.Count.Should().Be(expected.Count);

        foreach (var iconSize in iconSizes)
        {
            expected.Should().Contain(iconSize);
        }
    }
}
