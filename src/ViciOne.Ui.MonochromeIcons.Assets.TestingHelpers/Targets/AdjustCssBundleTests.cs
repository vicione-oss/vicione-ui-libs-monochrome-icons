using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AwesomeAssertions;

namespace ViciOne.Ui.MonochromeIcons.Assets.TestingHelpers.Targets;

/// <summary>
/// Tests for the behavior implemented in AdjustCssBundle.targets.
/// </summary>
public class AdjustCssBundleTests
{
    private readonly string _expectedImportRegex =
        @"@import\s+'/?_content/ViciOne\.Ui\.MonochromeIcons\.Assets/ViciOne\.Ui\.MonochromeIcons\.Assets\.[^.]+\.bundle\.scp\.css';";

    /// <summary>
    /// Builds the specified project and asserts that the scoped CSS bundle file contains the expected import statement
    /// for the assets package.
    /// </summary>
    public void BuildProjectAndAssertCssBundleWithAssetsImportExists(string projectPath, string cssBundleFileName)
    {
        // Arrange, Act (build)
        var processStartInfo = new ProcessStartInfo("dotnet", "build")
        {
            WorkingDirectory = projectPath
        };

        using var process = Process.Start(processStartInfo);

        process.Should().NotBeNull($"Failed to start process with {processStartInfo.FileName} {processStartInfo.Arguments}");

        var success = process.WaitForExit(120_000);
        if (!success)
        {
            try
            {
                process.Kill(entireProcessTree: true);
            }
            catch (InvalidOperationException)
            {
                // Process already exited.
            }
        }

        // Assert that scoped css bundle contains injected import
        success.Should().BeTrue();

        var bundleDir = Path.Combine(projectPath, "obj", "Debug", "net10.0", "scopedcss", "bundle");
        Directory.Exists(bundleDir).Should().BeTrue($"Expected directory to exist: {bundleDir}");

        var bundleCssFile = Directory
            .EnumerateFiles(bundleDir, "*.styles.css", SearchOption.TopDirectoryOnly)
            .FirstOrDefault(f => Path.GetFileName(f).Equals(cssBundleFileName, StringComparison.OrdinalIgnoreCase))
            ?? Path.Combine(bundleDir, cssBundleFileName);

        File.Exists(bundleCssFile).Should().BeTrue($"Expected scoped css bundle to exist: {bundleCssFile}");

        var css = File.ReadAllText(bundleCssFile);
        css.Should().MatchRegex(_expectedImportRegex);
    }
}
