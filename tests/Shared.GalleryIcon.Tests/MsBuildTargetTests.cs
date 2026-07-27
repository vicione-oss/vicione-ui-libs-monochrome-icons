using ViciOne.Ui.MonochromeIcons.Assets.TestingHelpers.Targets;
using Xunit;

namespace Shared.GalleryIcon.Tests;

public sealed class MsBuildTargetTests
{
    private readonly AdjustCssBundleTests _adjustCssBundleTests = new();

    [Fact]
    public void Should_execute_targets_of_assets_package_when_components_are_referenced_transitively()
    {
        // Arrange
        var assemblyDirectory = Path.GetDirectoryName(typeof(MsBuildTargetTests).Assembly.Location);

        if (assemblyDirectory is null)
            Assert.Fail("Failed to get test assembly directory.");

        var projectPath = Path.GetFullPath(
            Path.Combine(assemblyDirectory, "..", "..", "..", "..", "..", "samples", "Shared.GalleryIcon"));

        // Act, Assert
        _adjustCssBundleTests.BuildProjectAndAssertCssBundleWithAssetsImportExists(projectPath,
            cssBundleFileName: "Shared.GalleryIcon.styles.css");
    }
}
