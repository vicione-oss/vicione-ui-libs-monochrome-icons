using AwesomeAssertions;
using ViciOne.Ui.MonochromeIcons.Assets.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Factories;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Assets.Tests.Extensions;

public sealed class MonochromeIconNameExtensionsTests
{
    public static readonly TheoryData<string> IconNames = [.. TypeSafeEnumFactory<MonochromeIconName>.CreateAll().GetNames()];

    [Theory]
    [MemberData(nameof(IconNames))]
    public void AssertGetSvgMarkupResult(string iconName)
    {
        // Arrange
        var iconNameTyped = TypeSafeEnumFactory<MonochromeIconName>.Create(iconName);

        // Act
        var svgMarkup = iconNameTyped.GetSvgMarkup(MonochromeIconSize.Medium);

        // Assert
        svgMarkup.Should().NotBeEmpty();
    }
}
