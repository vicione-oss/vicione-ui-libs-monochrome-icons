# ViciOne Monochrome Icons

[[_TOC_]]

## Introduction

This repository contains icons with monochrome characteristic. An icon has a name formatted in `dash-case`, is stored as [scalable vector graphics](https://wikipedia.org/wiki/Scalable_Vector_Graphics) and it can have different sizes.

## Get started

- Clone repository
- Open console at root of cloned repository
- Run `npm ci`
- Run `dotnet build src/ViciOne.Ui.MonochromeIcons.Assets`
- Run the sample application

  | Technology | Command | URL |
  |-|-|-|
  | Blazor Server | `dotnet run --project samples/Server` | `https://localhost:57018` |
  | Blazor WebAssembly | `dotnet run --project samples/Client` | `https://localhost:54399` |

## How to maintain / extend the icon set

- As a developer, [get started](#get-started) first, then identify the icon via its name and / or size that needs maintenance / needs to be added or removed
- Create an issue describing what needs to be done / discussed, include the icon name in the description
- Make [Rocco Jaehnig](https://git.nsc-gmbh.de/rocco.jaehnig) the [Assignee](https://docs.gitlab.com/ee/user/project/issues/managing_issues.html#assignee)
- [Rocco Jaehnig](https://git.nsc-gmbh.de/rocco.jaehnig) creates a `.zip` export with a [predefined structure](https://git.nsc-gmbh.de/vo-ui/vo-monochrome-icons/-/issues/13#note_146109) in Sketch containing the icon, attaches it to the issue and additionally makes a Developer the Assignee
- As a developer, download and open the `.zip` export, extract [contents](https://git.nsc-gmbh.de/vo-ui/vo-monochrome-icons/-/issues/13#note_146109) of `dark-theme/icon/monochrome` to [`src/ViciOne.Ui.MonochromeIcons.Assets/Sketch.Incoming`](src/ViciOne.Ui.MonochromeIcons.Assets/Sketch.Incoming)
- Open solution
- If an icon was added / removed or renamed then ...
  - Update enum [`MonochromeIconName`](src/ViciOne.Ui.MonochromeIcons.Core/Enums/MonochromeIconName.cs)
  - Update MSBuild item [`MonochromeIconName`](src/ViciOne.Ui.MonochromeIcons.Core/ViciOne.Ui.MonochromeIcons.Core.targets)
- If an icon size was added / removed then ...
  - Update enum [`MonochromeIconSize`](src/ViciOne.Ui.MonochromeIcons.Core/Enums/MonochromeIconSize.cs)
  - Update MSBuild item [`MonochromeIconSize`](src/ViciOne.Ui.MonochromeIcons.Core/ViciOne.Ui.MonochromeIcons.Core.targets)
- Run `dotnet build src/ViciOne.Ui.MonochromeIcons.Assets`

  > This command will execute a chain of MSBuild targets to bring the files in `Sketch.Incoming` to `wwwroot`, see [`src/ViciOne.Ui.MonochromeIcons.Assets/README.md`](src/ViciOne.Ui.MonochromeIcons.Assets/README.md) for futher details.

- Run `dotnet test tests/ViciOne.Ui.MonochromeIcons.Assets.Tests`

  > The tests provided ensure that the imported icons meet predefined specifications.
  > When a test fails, its name indicates what specific issue is detected, for example `ShouldBeMinified` means `.svg` needs to be minified. Fix the associated `.svg` file in [src/ViciOne.Ui.MonochromeIcons.Assets/Sketch](src/ViciOne.Ui.MonochromeIcons.Assets/Sketch) and re-run tests until all tests pass. This is a manual operation until [Sanitize SVGs via MSBuild task](https://git.nsc-gmbh.de/vo-ui/vo-monochrome-icons/-/issues/11) is implemented.

- Add the new icon(s) to [`MsBuildTargetTests.cs`](tests/Shared.Tests/MsBuildTargetTests.cs)
- Add the new icon(s) to [`MonochromeIconNameFactoryTests.cs`](tests/ViciOne.Ui.MonochromeIcons.Core.Tests/Factories/MonochromeIconNameFactoryTests.cs)
- Update [`CHANGELOG.md`](CHANGELOG.md)
- Commit changes
- Create merge request
- Deploy NuGet package via the jobs provided in the merge request
- Install the deployed package in your application and test changes
- Complete merge request
- [Release](https://git.nsc-gmbh.de/tooling/templates/-/tree/master/Projekteigenschaften?ref_type=heads#versionierung) package with a new version

## How to consume icons

- Install package [`ViciOne.Ui.MonochromeIcons.Assets`](src/ViciOne.Ui.MonochromeIcons.Assets/ViciOne.Ui.MonochromeIcons.Assets.csproj)

  ``` powershell
  Install-Package ViciOne.Ui.MonochromeIcons.Assets
  ```

- Make package only a build dependency in your `.csproj`

  ``` xml
  <PackageReference Include="ViciOne.Ui.MonochromeIcons.Assets">
    <PrivateAssets>all</PrivateAssets><!-- avoids include of CSS isolation bundle -->
    <ExcludeAssets>runtime</ExcludeAssets><!-- don't depend on assembly at runtime -->
  </PackageReference>
  ```

- Configure [targets shipped with the package](src/ViciOne.Ui.MonochromeIcons.Assets/ViciOne.Ui.MonochromeIcons.Assets.targets) in your `.csproj`

  ``` xml
  <Target Name="ConfigureMonochromeIcons" BeforeTargets="BeforeMonochromeIconTargets">
    <!-- Specify required icons by icon name in dash-case and size -->
    <ItemGroup>
      <MonochromeIcon Include="refresh" Size="16;32" />
      <MonochromeIcon Include="switch-off" Size="32" />
      ...
    </ItemGroup>

    <!-- Specify target locations -->
    <PropertyGroup>
      <MonochromeIconSvgOutputFolder>$(MSBuildProjectDirectory)/wwwroot/icons/monochrome-icons</MonochromeIconSvgOutputFolder>
      <MonochromeIconScssOutputFolder>$(MSBuildProjectDirectory)/Styles/icons/monochrome-icons</MonochromeIconScssOutputFolder>
    </PropertyGroup>
  </Target>
  ```

- Include SCSS via [`@use ... with`](https://sass-lang.com/documentation/at-rules/use/#configuration)

  ``` scss
  @use "../Styles/icons/monochrome-icons" with (
    // Optional, adjust SVG output url resulting from <MonochromeIconSvgOutputFolder> specified in your .csproj
    $svg-base-url: "./icons/monochrome-icons",

    // Optional, adjust base selector according to your needs, pass ::deep to make styles work with CSS isolation
    $base-selector: "::deep",

    // Optional, apply a filter to ensure CSS classes for specific icon variants are generated
    $icon-filters: [
      (name: "refresh", size: 16 32),
      (name: "switch-off", size: 32)
    ]
  );
  ```

- Optionally, but recommended, use component [`MonochromeIcon`](src/ViciOne.Ui.MonochromeIcons.Components/MonochromeIcon.razor.cs) to render icons

  `.csproj`

  ```
  Install-Package ViciOne.Ui.MonochromeIcons.Components
  ```

  `.razor`

  ``` xml
  @using ViciOne.Ui.MonochromeIcons.Core.Enums
  @using ViciOne.Ui.MonochromeIcons.Components

  <MonochromeIcon Name="@MonochromeIconName.Refresh" Size="@MonochromeIconSize.Small" />
  <MonochromeIcon Name="@MonochromeIconName.SwitchOff" />
  ```

- Alternatively, you can use CSS classes to style an HTML element

  | CSS class | Description | Required
  |-|-|-|
  | `monochrome-icon` | Main class to apply icon defaults | Yes |
  | `monochrome-icon-{name}` | Name modifier to include the icon by name | Yes |
  | `size-{value}` | Size modifier to adjust the icon size, `{value}` is a value defined in `.csproj` via `Size` metadata of `MonochromeIcon` item | No, defaults to `32` |

  Example

  ```
  <i class="monochrome-icon monochrome-icon-refresh size-16"></i>
  ```

## How to work with the solution in VS

Doing a simple solution rebuild is not supported as `ViciOne.Ui.MonochromeIcons.Assets` needs to be built as a NuGet package first. So, when something is changed in the aforementioned project, then you need to apply the following steps:

- Rebuild `src/ViciOne.Ui.MonochromeIcons.Assets`
- Rebuild `src/ViciOne.Ui.MonochromeIcons.Components`
- Rebuild sample application

  | Technology | Folder |
  |-|-|
  | Blazor Server | `samples/Server` |
  | Blazor WebAssembly | `samples/Client` |
