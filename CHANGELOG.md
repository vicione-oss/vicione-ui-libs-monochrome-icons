# Changelog

## 4.5.0 - 2026-03-18

- Update to .NET `10.0.4`
- `MonochromeIconSize`, added `SmallPlus2` to allow an icon size of 18px

## 4.4.0 - 2026-03-11

- Added icon `calendar-light`, `calendar-solid`, `database-server`, `favorite-light-default`, `favorite-solid-default`, `filter-solid`, `filter-solid-close`, `full-size-exit-light`, `full-size-light`, `info-light`, `info-solid`, `navigate-light`, `navigate-solid`, `server-light`, `server-network-light`, `server-network-solid`, `server-solid`, `today-light`, `today-solid`, `topology-application-light`, `topology-engine-light`, `topology-folder-network-light`

## 4.3.0 - 2026-02-26

- Added icon `install-pending-light`, `send-light.svg`, `send-solid.svg`, `uninstall-pending-light`, `uninstall-light`, `update-available-light`, `update-light.svg`, `wifi.svg` and `kebab-menu`

## 4.2.0 - 2026-01-28

- Added icon `add`, `all-predecessors`, `all-predecessors-and-successors`, `all-successors`, `attached`, `bring-forward`, `check-circled-light`, `clear`, `collapse-all`, `column-chooser-editor`, `column-chooser-menu`, `connector-dragging-connector-in`, `connector-dragging-connector-out`, `dataflow-jump-into`, `dummy-icon`, `expand-all`, `filter-solid-input`, `filter-solid-output`, `group-by-category`, `invert`, `move-down`, `move-left`, `move-right`, `move-up`, `onboarding`, `predecessor`, `published-connector-dragging`, `selected`, `send-backward`, `several-to-back`, `several-to-front`, `sort-children`, `sort-default`, `sort-uncheck-all`, `successor-and-predecessor`, `successor`, `template-badge`, `template-editor`, `template-management`, `zoom-100` and `zoom-to-fit`
- Updated icon `search`

## 4.1.0 - 2026-01-19

- Updated package project URL to reflect the migration to gitlab.com

## 4.0.1 - 2026-01-09

- Changed license to MIT

## 4.0.0 - 2026-01-08

- Added license
- Update to .NET 10

## 3.10.0 - 2025-11-28

- Fixed broken builds with .NET version > `9.0.203`
- Placement of scaled icons is not affected by `text-align` applied by external CSS rules anymore
- `ViciOne.Ui.MonochromeIcons.Core`, provides MSBuild item `MonochromeIconName` and `MonochromeIconSize`
- Extended sample app to be more helpful for users of the library

## 3.9.0 - 2025-11-05

- Added icon `add-text-labels-solid`, `container-add`, `move-to-new-container` and `select-all-blocks`
- Updated icon `connector-add-to-container`, `connector-cancel-publication`, `connector-publish` and `connector-remove-from-container`

## 3.8.0 - 2025-10-23

- Added icon `connector-add-to-container`, `connector-cancel-publication`, `connector-publish`, `connector-remove-from-container`, `container-dissolve-light`, `container-dissolve-solid`, `lock-text-labels-light`, `lock-text-labels-solid`, `minimap-light`, `select-all`, `select-connectors-input`, `select-connectors-input-all`, `select-connectors-input-and-output`, `select-connectors-input-and-output-all`, `select-connectors-output` and `select-connectors-output-all`

## 3.7.0 - 2025-10-15

- Optimized file size for icon `chevron`, `expander-light-down`, `expander-light-left`, `expander-light-right`, `expander-light-top` and `permission-view-and-edit`
- Update to .NET `9.0.10`
- Removed obsolete icon `dataflow` and `top-by-lowest-element`

## 3.6.1 - 2025-09-02

- Use of `!important` flag in CSS size modifiers to ensure correct application of styles

## 3.6.0 - 2025-06-11

- Added icon `system-messages-light` and `system-messages-solid`

## 3.5.0 - 2025-05-22

- Added icon `cloud-solid-connection`, `edit-host`, `instructions`, `key-light`, `key-solid`, `keychain-light`, `keychain-solid`, `network-topology`, `permission-none`, `permission-view-and-edit` and `permission-view-only`

## 3.4.0 - 2025-04-15

- Added icon `dataflow-light`, `dataflow-solid` and `time-out-light`
- Updated icon `export` and `import`
- Marked `dataflow` as obsolete

## 3.3.0 - 2025-02-07

- Added icon `language` and `user-interface-light`

## 3.2.1 - 2025-02-04

- Updated SCSS to avoid overriding our own styles

## 3.2.0 - 2025-01-14

- Added icon `tagging`

## 3.1.0 - 2025-01-02

- Added `icon-filters` option to SASS module

## 3.0.0 - 2024-12-03

- Update to .NET 9

## 2.3.0 - 2024-11-18

- Added icon `arrow-navigation-light-down`, `arrow-navigation-light-left`, `arrow-navigation-light-right`, `arrow-navigation-light-up` and `email`

## 2.2.0 - 2024-11-05

- Icon `home-solid` sanitized (`id` and `fill` attribute removed)
- Added icon `alarm-light`, `alarm-solid`, `delete`, `filter-light`, `gear-light`, `gear-solid`, `help-light`, `help-solid`, `offline-light`, `system-settings-light`, `system-settings-solid`, `user-light` and `user-solid`

## 2.1.0 - 2024-10-11

- Added icon `home-light`, `home-solid` and `search`

## 2.0.0 - 2024-10-10

- Restructure `MonochromeIconName` to type-safe enum pattern
- Added icon `rtm-warning` and `warning`

## 1.17.0 - 2024-09-30

- Added icon `add-user`, `hide`, `keyboard`, `lock-active`, `lock`, `reload` and `show`

## 1.16.0 - 2024-09-26

- Added icon `align-top-by-lowest-element`, marked `top-by-lowest-element` as obsolete

## 1.15.0 - 2024-09-05

- Updated `PackageProjectUrl`
- Added icon `bug-light`, `bug-solid`, `cluster-2`, `data-switch`, `library`, `properties`, `published-connector-full`, `search-and-tools` and `test-tube-solid`

## 1.14.0 - 2024-08-28

- Added MSBuild target `AfterMonochromeIconTargets`

## 1.13.0 - 2024-08-22

- Added icon `dataflow`, `export`, `hamburger-menu`, `import`, `new`, `new-in-wizard` and `save-outline`

## 1.12.0 - 2024-08-21

- Fixed bug in MSBuild target `CopyMonochromeIconSvgs`, icons are now correctly included in NuGet-Package

## 1.11.0 - 2024-07-29

- `ViciOne.Ui.MonochromeIcons.Core`
  - Moved `ViciOne.Ui.MonochromeIcons.Assets.Extensions.MonochromeIconNameExtensions.GetSvgPath()` to `MonochromeIconNameExtensions`
  - Added `MonochromeIconSizeExtensions.ToFolder()`

## 1.10.0 - 2024-07-29

- Added icon `cluster-1`

## 1.9.0 - 2024-07-24

- Added icon `edit` and `exit`

## 1.8.0 - 2024-07-22

- Added icon `plus-slim` and `minus-slim`

## 1.7.0 - 2024-07-22

- Added icon `check`

## 1.6.0 - 2024-07-16

- Added icon `general-menu`
- Added icon `close-slim`

## 1.5.0 - 2024-07-11

- `ViciOne.Ui.MonochromeIcons.Core`
  - Added `MonochromeIconNameExtensions.GetCssClasses()`
  - Added `MonochromeIconSizeExtensions.ToModifierCssClass()`
  - Added `StringExtensions.ToSpaceSeparated()`

## 1.4.0 - 2024-06-19

- Added icon `close-medium`

## 1.3.1 - 2024-04-17

- MSBuild target `CopyMonochromeIconSvgs`, default size of 32px is now copied to output folder when requested size does not exist

## 1.3.0 - 2024-04-17

- `MonochromeIconSize`, added `SmallMedium` to allow an icon size of 24px

## 1.2.0 - 2024-04-16

- Added icon `connectivity`, `error-full`, `external-link`, `info-outlined`, `open-in-new-window`, `this-week`, `timer`, `today`, `urgent`, `warning-full`

## 1.1.0 - Unreleased

- Fixed bug in CSS size modifier generation
- Fixed orientation of icon `chevron`
- Added icon `align-bottom`, `align-left`, `align-right`, `align-top`, `container`, `container-locked-action`, `container-locked-user`, `distribute-horizontally`, `distribute-vertically`, `duplicate`, `expander-light-down`, `expander-light-left`, `expander-light-right`, `expander-light-top`, `folder`, `json`, `json-field`, `json-field-in`, `json-field-out`, `json-in`, `json-out`, `local`, `on-off`, `open`, `paste`, `redo`, `refresh`, `switch-off`, `toggle`, `top-by-lowest-element`, `undo` and `wizard`

## 1.0.3 - 2024-03-28

- Assets, targets are executed before `PreBuildEvent`

## 1.0.2 - 2024-03-22

- Components, removed space in PackagePath to fix release pipeline error

## 1.0.1 - 2024-03-22

- `README.md`, remove unnecessary
- `CHANGELOG.md`, added missing release date for version `1.0.0`

## 1.0.0 - 2024-03-22

- Initial release
