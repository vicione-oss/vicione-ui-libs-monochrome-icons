using System.Diagnostics;
using System.IO;
using System.Linq;
using AwesomeAssertions;
using Xunit;

namespace Shared.Tests;

public sealed class MsBuildTargetTests
{
    [Fact]
    public void Should_execute_targets_of_assets_package()
    {
        // Arrange
        var assembly = typeof(MsBuildTargetTests).Assembly;
        var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
        if (assemblyDirectory is null)
            Assert.Fail($"Failed to get directory for {assembly.Location}");

        var clientProjectPath = Path.Combine(assemblyDirectory,
            "..", "..", "..", "..", "..", "samples", "Shared");

        var targetScssPath = Path.Combine(clientProjectPath, "Styles", "icons");
        if (Directory.Exists(targetScssPath))
            Directory.Delete(targetScssPath, true);

        var targetSvgPath = Path.Combine(clientProjectPath, "wwwroot", "icons");
        if (Directory.Exists(targetSvgPath))
            Directory.Delete(targetSvgPath, true);

        var expectedScssFiles = new[]
        {
            "_functions.scss",
            "_index.scss",
            "_mixins.scss",
            "_modifiers.scss",
            "_monochrome-icons.scss",
            "_variables.generated.scss",
            "_variables.generated.duplicate.scss",
            "_variables.scss"
        }.Select(expectedScssFile => Path.Combine(targetScssPath, "monochrome-icons", expectedScssFile));

        var expectedSvgFiles16x16 = new[]
        {
            "chevron.svg"
        }.Select(expectedSvgFile => Path.Combine(targetSvgPath, "monochrome-icons", "16x16", expectedSvgFile));

        var expectedSvgFiles32x32 = new[]
        {
            "add.svg",
            "add-text-labels-solid.svg",
            "add-user.svg",
            "alarm-light.svg",
            "alarm-solid.svg",
            "align-bottom.svg",
            "align-left.svg",
            "align-right.svg",
            "align-top.svg",
            "all-predecessors.svg",
            "all-predecessors-and-successors.svg",
            "all-successors.svg",
            "align-top-by-lowest-element.svg",
            "arrow-navigation-light-down.svg",
            "arrow-navigation-light-left.svg",
            "arrow-navigation-light-right.svg",
            "arrow-navigation-light-up.svg",
            "attached.svg",
            "bring-forward.svg",
            "bug-light.svg",
            "bug-solid.svg",
            "calendar-light.svg",
            "calendar-solid.svg",
            "check.svg",
            "check-circled-light.svg",
            "chevron.svg",
            "clear.svg",
            "close-medium.svg",
            "close-slim.svg",
            "cloud-solid-connection.svg",
            "cluster-1.svg",
            "cluster-2.svg",
            "collapse-all.svg",
            "column-chooser-editor.svg",
            "column-chooser-menu.svg",
            "connectivity.svg",
            "connector-add-to-container.svg",
            "connector-cancel-publication.svg",
            "connector-dragging-connector-in.svg",
            "connector-dragging-connector-out.svg",
            "connector-publish.svg",
            "connector-remove-from-container.svg",
            "container.svg",
            "container-add.svg",
            "container-dissolve-light.svg",
            "container-dissolve-solid.svg",
            "container-locked-action.svg",
            "container-locked-user.svg",
            "database-server.svg",
            "dataflow-jump-into.svg",
            "dataflow-light.svg",
            "dataflow-solid.svg",
            "data-switch.svg",
            "delete.svg",
            "distribute-horizontally.svg",
            "distribute-vertically.svg",
            "dummy-icon.svg",
            "duplicate.svg",
            "edit.svg",
            "edit-host.svg",
            "email.svg",
            "error-full.svg",
            "exit.svg",
            "expand-all.svg",
            "expander-light-down.svg",
            "expander-light-left.svg",
            "expander-light-right.svg",
            "expander-light-top.svg",
            "export.svg",
            "external-link.svg",
            "favorite-light-default.svg",
            "favorite-solid-default.svg",
            "filter-light.svg",
            "filter-solid.svg",
            "filter-solid-close.svg",
            "filter-solid-input.svg",
            "filter-solid-output.svg",
            "folder.svg",
            "full-size-exit-light.svg",
            "full-size-light.svg",
            "gear-light.svg",
            "gear-solid.svg",
            "general-menu.svg",
            "group-by-category.svg",
            "hamburger-menu.svg",
            "help-light.svg",
            "help-solid.svg",
            "home-light.svg",
            "home-solid.svg",
            "hide.svg",
            "import.svg",
            "info-light.svg",
            "info-outlined.svg",
            "info-solid.svg",
            "install-pending-light.svg",
            "instructions.svg",
            "invert.svg",
            "json.svg",
            "json-field.svg",
            "json-field-in.svg",
            "json-field-out.svg",
            "json-in.svg",
            "json-out.svg",
            "kebab-menu.svg",
            "key-light.svg",
            "key-solid.svg",
            "keyboard.svg",
            "keychain-light.svg",
            "keychain-solid.svg",
            "language.svg",
            "library.svg",
            "local.svg",
            "lock-active.svg",
            "lock-text-labels-light.svg",
            "lock-text-labels-solid.svg",
            "lock.svg",
            "minimap-light.svg",
            "minus-slim.svg",
            "move-down.svg",
            "move-left.svg",
            "move-right.svg",
            "move-to-new-container.svg",
            "move-up.svg",
            "navigate-light.svg",
            "navigate-solid.svg",
            "network-topology.svg",
            "new.svg",
            "new-in-wizard.svg",
            "offline-light.svg",
            "onboarding.svg",
            "on-off.svg",
            "open.svg",
            "open-in-new-window.svg",
            "paste.svg",
            "permission-none.svg",
            "permission-view-and-edit.svg",
            "permission-view-only.svg",
            "plus-slim.svg",
            "predecessor.svg",
            "properties.svg",
            "published-connector-dragging.svg",
            "published-connector-full.svg",
            "redo.svg",
            "refresh.svg",
            "reload.svg",
            "rtm-warning.svg",
            "save-outline.svg",
            "search.svg",
            "search-and-tools.svg",
            "select-all.svg",
            "select-all-blocks.svg",
            "select-connectors-input.svg",
            "select-connectors-input-all.svg",
            "select-connectors-input-and-output.svg",
            "select-connectors-input-and-output-all.svg",
            "select-connectors-output.svg",
            "select-connectors-output-all.svg",
            "selected.svg",
            "send-backward.svg",
            "send-light.svg",
            "send-solid.svg",
            "server-light.svg",
            "server-network-light.svg",
            "server-network-solid.svg",
            "server-solid.svg",
            "several-to-back.svg",
            "several-to-front.svg",
            "show.svg",
            "sort-children.svg",
            "sort-default.svg",
            "sort-uncheck-all.svg",
            "successor.svg",
            "successor-and-predecessor.svg",
            "switch-off.svg",
            "system-messages-light.svg",
            "system-messages-solid.svg",
            "system-settings-light.svg",
            "system-settings-solid.svg",
            "tagging.svg",
            "template-badge.svg",
            "template-editor.svg",
            "template-management.svg",
            "test-tube-solid.svg",
            "this-week.svg",
            "time-out-light.svg",
            "timer.svg",
            "today.svg",
            "today-light.svg",
            "today-solid.svg",
            "toggle.svg",
            "topology-application-light.svg",
            "topology-engine-light.svg",
            "topology-folder-network-light.svg",
            "undo.svg",
            "uninstall-light.svg",
            "uninstall-pending-light.svg",
            "update-available-light.svg",
            "update-light.svg",
            "urgent.svg",
            "user-interface-light.svg",
            "user-light.svg",
            "user-solid.svg",
            "warning.svg",
            "warning-full.svg",
            "wifi.svg",
            "wifi-off.svg",
            "wizard.svg",
            "zoom-100.svg",
            "zoom-to-fit.svg"
        }.Select(expectedSvgFile => Path.Combine(targetSvgPath, "monochrome-icons", "32x32", expectedSvgFile));

        var expectedSvgFiles = expectedSvgFiles16x16.Union(expectedSvgFiles32x32);

        // Act
        var processStartInfo = new ProcessStartInfo("dotnet", "build")
        {
            WorkingDirectory = clientProjectPath
        };

        var process = Process.Start(processStartInfo);
        if (process is null)
            Assert.Fail($"Failed to start process with {processStartInfo}");

        var success = process.WaitForExit(30000);

        // Assert
        success.Should().BeTrue();

        var copiedScssFiles = Directory.GetFiles(targetScssPath, "*", new EnumerationOptions { RecurseSubdirectories = true });
        copiedScssFiles.Should().BeEquivalentTo(expectedScssFiles);

        var copiedSvgFiles = Directory.GetFiles(targetSvgPath, "*", new EnumerationOptions { RecurseSubdirectories = true });
        copiedSvgFiles.Should().BeEquivalentTo(expectedSvgFiles);
    }
}
