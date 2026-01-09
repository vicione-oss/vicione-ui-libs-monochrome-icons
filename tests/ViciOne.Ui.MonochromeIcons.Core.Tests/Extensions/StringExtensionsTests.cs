using AwesomeAssertions;
using Xunit;
using ViciOne.Ui.MonochromeIcons.Core.Extensions;
using System.Collections.Generic;

namespace ViciOne.Ui.MonochromeIcons.Core.Tests.Extensions;

public sealed class StringExtensionsTests
{
    [Theory]
    [InlineData("camelCaseString", "camel-case-string")]
    [InlineData("CamelCaseString", "camel-case-string")]
    [InlineData("Cluster1", "cluster-1")]
    [InlineData("Cluster1Two3", "cluster-1-two-3")]
    public void AssertToDashCaseResult(string givenValue, string expectedValue)
    {
        // Act
        var result = givenValue.ToDashCase();

        // Assert
        result.Should().Be(expectedValue);
    }

    [Fact]
    public void AssertToSpaceSeparatedResult()
    {
        // Arrange
        var values = new List<string> { "A", "B" };

        // Act
        var result = values.ToSpaceSeparated();

        // Assert
        result.Should().Be("A B");
    }
}
