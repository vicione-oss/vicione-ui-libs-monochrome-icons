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
    public void Should_render_component()
    {
        // Arrange
        using var ctx = new BunitContext();

        // Act
        var renderedComponent = ctx.Render<MonochromeIcon>(b => b
            .Add(p => p.Name, MonochromeIconName.Refresh));

        // Assert
        renderedComponent.Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(IconNames))]
    public void Should_render_icon(string iconName)
    {
        // Arrange
        var iconNameTyped = TypeSafeEnumFactory<MonochromeIconName>.Create(iconName);
        using var ctx = new BunitContext();

        // Act
        var renderedComponent = ctx.Render<MonochromeIcon>(b => b
            .Add(p => p.Name, iconNameTyped));

        // Assert
        var icon = renderedComponent.Find("i");
        icon.ClassList.Should().Contain("monochrome-icon");
        icon.ClassList.Should().Contain($"monochrome-icon-{iconNameTyped.ToString().ToDashCase()}");
    }

    [Theory]
    [MemberData(nameof(IconSizes))]
    public void Assert_size_modifier(string iconSize)
    {
        // Arrange
        var iconSizeTyped = TypeSafeEnumFactory<MonochromeIconSize>.Create(iconSize);

        using var ctx = new BunitContext();

        var sizeModifier = $"size-{iconSizeTyped.ToPixels()}";
        var shouldRenderSizeModifier = iconSizeTyped != MonochromeIconSize.Medium;

        // Act
        var renderedComponent = ctx.Render<MonochromeIcon>(b => b
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
    public void Should_render_css_class()
    {
        // Arrange
        using var ctx = new BunitContext();

        const string CssClass1 = "shiny";
        const string CssClass2 = "flashy";

        // Act
        var renderedComponent = ctx.Render<MonochromeIcon>(b => b
            .Add(p => p.Name, MonochromeIconName.Refresh)
            .Add(p => p.CssClass, $"{CssClass1} {CssClass2}"));

        // Assert
        var icon = renderedComponent.Find("i");
        icon.ClassList.Should().Contain(CssClass1);
        icon.ClassList.Should().Contain(CssClass2);
    }
}
