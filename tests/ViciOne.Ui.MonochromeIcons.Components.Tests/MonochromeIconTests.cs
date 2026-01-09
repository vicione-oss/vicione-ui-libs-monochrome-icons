using Bunit;
using AwesomeAssertions;
using ViciOne.Ui.MonochromeIcons.Components;
using ViciOne.Ui.MonochromeIcons.Core.Enums;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using ViciOne.Ui.MonochromeIcons.Core.Factories;
using Xunit;

namespace ViciOne.Ui.MonochromeIcons.Assets.Components.Tests;

public sealed class MonochromeIconTests
{
    public static readonly TheoryData<string> IconNames = [.. TypeSafeEnumFactory<MonochromeIconName>.CreateAll().GetNames()];
    public static readonly TheoryData<string> IconSizes = [.. TypeSafeEnumFactory<MonochromeIconSize>.CreateAll().GetNames()];

    [Fact]
    public void ShouldRenderComponent()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var renderedComponent = ctx.RenderComponent<MonochromeIcon>(b => b
            .Add(p => p.Name, MonochromeIconName.Refresh));

        // Assert
        renderedComponent.Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(IconNames))]
    public void ShouldRenderIcon(string iconName)
    {
        // Arrange
        var iconNameTyped = TypeSafeEnumFactory<MonochromeIconName>.Create(iconName);
        using var ctx = new TestContext();

        // Act
        var renderedComponent = ctx.RenderComponent<MonochromeIcon>(b => b
            .Add(p => p.Name, iconNameTyped));

        // Assert
        var icon = renderedComponent.Find("i");
        icon.ClassList.Should().Contain("monochrome-icon");
        icon.ClassList.Should().Contain($"monochrome-icon-{iconNameTyped.ToString().ToDashCase()}");
    }

    [Theory]
    [MemberData(nameof(IconSizes))]
    public void AssertSizeModifier(string iconSize)
    {
        // Arrange
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        using var ctx = new TestContext();

        var sizeModifier = $"size-{iconSizeTyped.ToPixels()}";
        var shouldRenderSizeModifier = iconSizeTyped != MonochromeIconSize.Medium;

        // Act
        var renderedComponent = ctx.RenderComponent<MonochromeIcon>(b => b
            .Add(p => p.Name, MonochromeIconName.Refresh)
            .Add(p => p.Size, iconSizeTyped));

        // Assert
        var icon = renderedComponent.Find("i");

        if (shouldRenderSizeModifier)
            icon.ClassList.Should().Contain(sizeModifier);
        else
            icon.ClassList.Should().NotContain(sizeModifier);
    }

    [Fact]
    public void ShouldRenderCssClass()
    {
        // Arrange
        using var ctx = new TestContext();

        const string CssClass1 = "shiny";
        const string CssClass2 = "flashy";

        // Act
        var renderedComponent = ctx.RenderComponent<MonochromeIcon>(b => b
            .Add(p => p.Name, MonochromeIconName.Refresh)
            .Add(p => p.CssClass, $"{CssClass1} {CssClass2}"));

        // Assert
        var icon = renderedComponent.Find("i");
        icon.ClassList.Should().Contain(CssClass1);
        icon.ClassList.Should().Contain(CssClass2);
    }
}
