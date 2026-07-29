using System.Diagnostics;
using AwesomeAssertions;

namespace ViciOne.Ui.MonochromeIcons.Assets.TestingHelpers.Targets;

/// <summary>
/// Tests for the behavior implemented in AdjustCssBundle.targets.
/// </summary>
public class AdjustCssBundleTests
{
    // Deterministic, machine-wide name shared by all test processes so that the concurrent
    // sample builds (started from separate test assemblies running in parallel) are serialized.
    // A named mutex is cross-process on Windows and on Linux/macOS in modern .NET.
    private const string BuildMutexName = "vicione-monochrome-icons-msbuild-targets";

    private readonly string _expectedImportRegex =
        @"@import\s+'/?_content/ViciOne\.Ui\.MonochromeIcons\.Assets/ViciOne\.Ui\.MonochromeIcons\.Assets\.[^.]+\.bundle\.scp\.css';";

    /// <summary>
    /// Builds the specified project and asserts that the scoped CSS bundle file contains the expected import statement
    /// for the assets package. The build is serialized across processes via a named mutex. The build always runs and
    /// relies on MSBuild's own up-to-date check to keep repeated builds cheap.
    /// </summary>
    /// <param name="projectPath">The directory of the project to build.</param>
    /// <param name="cssBundleFileName">The expected scoped CSS bundle file name (e.g. "Shared.styles.css").</param>
    public void BuildProjectAndAssertCssBundleWithAssetsImportExists(string projectPath, string cssBundleFileName)
    {
        // Build and assert against a single, fixed configuration (Debug) so that the produced
        // artifacts and the asserted paths stay consistent, independent of the test host's configuration.
        var bundleDir = Path.Combine(projectPath, "obj", "Debug", "net10.0", "scopedcss", "bundle");

        // Serialize the build and the subsequent bundle verification across processes: the lock is held
        // during both the build and the file inspection so that another process building an overlapping
        // project graph cannot overwrite the bundle files while they are being read.
        using (AcquireBuildLock())
        {
            RunBuild(projectPath);

            // Assert that scoped css bundle contains injected import.
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

    private static void RunBuild(string projectPath)
    {
        const int BuildTimeoutMilliseconds = 120_000;

        var processStartInfo = new ProcessStartInfo("dotnet", "build --no-incremental")
        {
            WorkingDirectory = projectPath
        };

        using var process = Process.Start(processStartInfo);

        process.Should().NotBeNull($"Failed to start process with {processStartInfo.FileName} {processStartInfo.Arguments}");

        var success = process.WaitForExit(BuildTimeoutMilliseconds);
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

        success.Should().BeTrue();
    }

    private static MutexReleaser AcquireBuildLock()
    {
        const int LockTimeoutMilliseconds = 300_000;

        var mutex = new Mutex(initiallyOwned: false, BuildMutexName);

        bool acquired;
        try
        {
            // WaitOne returns true when ownership is acquired. If a previous owner crashed without
            // releasing, AbandonedMutexException is thrown but ownership is still granted.
            acquired = mutex.WaitOne(LockTimeoutMilliseconds);
        }
        catch (AbandonedMutexException)
        {
            acquired = true;
        }

        if (!acquired)
        {
            mutex.Dispose();
            throw new TimeoutException(
                $"Timed out after {LockTimeoutMilliseconds} ms waiting for the MSBuild target test mutex: {BuildMutexName}");
        }

        return new MutexReleaser(mutex);
    }

    private sealed class MutexReleaser(Mutex mutex) : IDisposable
    {
        public void Dispose()
        {
            try
            {
                mutex.ReleaseMutex();
            }
            finally
            {
                mutex.Dispose();
            }
        }
    }
}
