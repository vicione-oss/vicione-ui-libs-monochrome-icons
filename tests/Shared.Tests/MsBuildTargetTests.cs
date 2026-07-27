using ViciOne.Ui.MonochromeIcons.Assets.TestingHelpers.Targets;
using Xunit;

namespace Shared.Tests;

public sealed class MsBuildTargetTests
{
    private readonly AdjustCssBundleTests _adjustCssBundleTests = new();

    [Fact]
    public void Should_execute_targets_of_assets_package()
    {
        // Arrange
        var assemblyDirectory = Path.GetDirectoryName(typeof(MsBuildTargetTests).Assembly.Location);

        if (assemblyDirectory is null)
            Assert.Fail("Failed to get test assembly directory.");

        var sharedProjectPath = Path.GetFullPath(Path.Combine(
            assemblyDirectory, "..", "..", "..", "..", "..", "samples", "Shared"));

        // Act, Assert
        _adjustCssBundleTests.BuildProjectAndAssertCssBundleWithAssetsImportExists(sharedProjectPath,
            cssBundleFileName: "Shared.styles.css");
    }
}
