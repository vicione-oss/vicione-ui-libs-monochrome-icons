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
  | Blazor Web App (Interactive Server) | `dotnet run --project samples/ViciOne.Ui.MonochromeIcons.Samples.BlazorWebApp --launch-profile "Interactive Server"` | `https://localhost:57118` |
  | Blazor Web App (Interactive WebAssembly) | `dotnet run --project samples/ViciOne.Ui.MonochromeIcons.Samples.BlazorWebApp --launch-profile "Interactive WebAssembly"` | `https://localhost:57119` |
  | Blazor WebAssembly Standalone App | `dotnet run --project samples/ViciOne.Ui.MonochromeIcons.Samples.BlazorWebAssemblyStandaloneApp` | `https://localhost:54401` |

## How to maintain / extend the icon set

- As a developer, [get started](#get-started) first, then identify the icon via its name and / or size that needs maintenance / needs to be added or removed
- Create an issue describing what needs to be done / discussed, include the icon name in the description
- Make [rjae_ifm](https://gitlab.com/rjae_ifm) (UX designer) the [Assignee](https://docs.gitlab.com/ee/user/project/issues/managing_issues.html#assignee)
- The UX designer creates a `.zip` export in Sketch containing the icon in a [predefined structure](https://gitlab.com/vicione-oss/vicione/ui-libs/monochrome-icons/-/work_items/116#note_3006882517), attaches it to the issue and then makes a developer the Assignee
- As a developer, download and open the `.zip` export, extract contents of `dark-theme/icon/monochrome` to [`src/ViciOne.Ui.MonochromeIcons.Assets/Sketch.Incoming`](src/ViciOne.Ui.MonochromeIcons.Assets/Sketch.Incoming)
- Open solution
- If an icon was added / removed or renamed then ...
  - Update enum [`MonochromeIconName`](src/ViciOne.Ui.MonochromeIcons.Core/Enums/MonochromeIconName.cs)
- If an icon size was added / removed then ...
  - Update enum [`MonochromeIconSize`](src/ViciOne.Ui.MonochromeIcons.Core/Enums/MonochromeIconSize.cs)
- Run `dotnet build src/ViciOne.Ui.MonochromeIcons.Assets`

  > This command will execute a chain of MSBuild targets to bring the files in `Sketch.Incoming` to `wwwroot`, see [`src/ViciOne.Ui.MonochromeIcons.Assets/README.md`](src/ViciOne.Ui.MonochromeIcons.Assets/README.md) for futher details.

- Run `dotnet test tests/ViciOne.Ui.MonochromeIcons.Assets.Tests`

  > The tests provided ensure that the imported icons meet predefined specifications.
  > When a test fails, its name indicates what specific issue is detected, for example `ShouldBeMinified` means `.svg` needs to be minified. Fix the affected `.svg` file, copy it back to [`src/ViciOne.Ui.MonochromeIcons.Assets/Sketch.Incoming`](src/ViciOne.Ui.MonochromeIcons.Assets/Sketch.Incoming), rebuild the assets project and re-run the tests until all tests pass.

- Add the new icon(s) to [`MonochromeIconNameFactoryTests.cs`](tests/ViciOne.Ui.MonochromeIcons.Core.Tests/Factories/MonochromeIconNameFactoryTests.cs)
- Update [`CHANGELOG.md`](CHANGELOG.md)
- Commit changes
- Create merge request
- Deploy NuGet package via the jobs provided in the merge request
- Install the deployed package in your application and test changes
- Complete merge request
- [Release](https://gitlab.com/vicione-oss/tooling/templates/-/tree/master/ProjectProperties?ref_type=heads#versioning) package with a new version

## How to consume icons

There are various ways to consume icons, depending on the use-case.

### Render icons in Blazor

- Install package [`ViciOne.Ui.MonochromeIcons.Components`](src/ViciOne.Ui.MonochromeIcons.Components/ViciOne.Ui.MonochromeIcons.Components.csproj)

  ``` powershell
  Install-Package ViciOne.Ui.MonochromeIcons.Components
  ```
- Use component [`MonochromeIcon`](src/ViciOne.Ui.MonochromeIcons.Components/MonochromeIcon.razor.cs) to render icons

  ``` xml
  @* Foo.razor *@

  @using ViciOne.Ui.MonochromeIcons.Core.Enums
  @using ViciOne.Ui.MonochromeIcons.Components

  <MonochromeIcon Name="@MonochromeIconName.Refresh" Size="@MonochromeIconSize.Small" />
  ```

### ... or use CSS classes

- Install package [`ViciOne.Ui.MonochromeIcons.Assets`](src/ViciOne.Ui.MonochromeIcons.Components/ViciOne.Ui.MonochromeIcons.Assets.csproj)

  ``` powershell
  Install-Package ViciOne.Ui.MonochromeIcons.Assets
  ```

  > This step is only necessary when you don't have a reference to `ViciOne.Ui.MonochromeIcons.Components`.

  > If your project is not using [`CSS isolation`](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation), then you need to manually reference / import the CSS styles via URL `/_content/ViciOne.Ui.MonochromeIcons.Assets/styles.css`.

- Now, use extension method [`GetCssClasses()`](src/ViciOne.Ui.MonochromeIcons.Core/Extensions/MonochromeIconNameExtensions.cs#L15) ...

    ``` csharp
    // Foo.cs

    using ViciOne.Ui.MonochromeIcons.Core.Enums;
    using ViciOne.Ui.MonochromeIcons.Core.Extensions;

    var cssClass = MonochromeIconName.AlarmSolid.GetCssClasses(MonochromeIconSize.MediumLarge)
        .ToSpaceSeparated();
    ```

    > The variable `cssClass` can now be used to fill the `class` attribute of an HTML element.

- ... or use CSS classes directly (not recommended as code is relying on implementation details that can change in any moment)

  | CSS class | Description | Required
  |-|-|-|
  | `monochrome-icon` | Main class to apply icon defaults | Yes |
  | `monochrome-icon-{name}` | Name modifier to include the icon by name | Yes |
  | `size-{value}` | Size modifier to adjust the icon size, `{value}` is a value defined in `.csproj` via `Size` metadata of `MonochromeIcon` item | No, defaults to `32` |

  ``` html
  <i class="monochrome-icon monochrome-icon-refresh size-16"></i>
  ```

### ... or retrieve icon SVG markup

#### Install package

- Install package [`ViciOne.Ui.MonochromeIcons.Assets`](src/ViciOne.Ui.MonochromeIcons.Components/ViciOne.Ui.MonochromeIcons.Assets.csproj)

  ``` powershell
  Install-Package ViciOne.Ui.MonochromeIcons.Assets
  ```

  > This step is only necessary when you don't have a reference to `ViciOne.Ui.MonochromeIcons.Components` already.

#### Use `IMonochromeIconSvgMarkupProvider`

- Register suitable implementation for [`IMonochromeIconSvgMarkupProvider`](src/ViciOne.Ui.MonochromeIcons.Assets/Services/IMonochromeIconSvgMarkupProvider.cs)

  - **Blazor Server** applications should use [`FileSystemBasedMonochromeIconSvgMarkupProvider`](src/ViciOne.Ui.MonochromeIcons.Assets/Services/FileSystemBasedMonochromeIconSvgMarkupProvider.cs)

    ``` csharp
    using ViciOne.Ui.MonochromeIcons.Assets.Extensions;

    services.AddFileSystemBasedMonochromeIconSvgMarkupProvider();
    ```

    > The extension method call above registers a default implementation based on content root retrieved from file `staticwebassets.runtime.json`.
    > The default implementation can be customized by registering own implementations of [`IStaticWebAssetsRuntimeJsonBaseFilenameProvider`](src/ViciOne.Ui.MonochromeIcons.Assets/Services/IStaticWebAssetsRuntimeJsonBaseFilenameProvider.cs), [`IStaticWebAssetsRuntimeJsonPathProvider`](src/ViciOne.Ui.MonochromeIcons.Assets/Services/IStaticWebAssetsRuntimeJsonPathProvider.cs) and [`IFileSystemBasedContentRootProvider`](src/ViciOne.Ui.MonochromeIcons.Assets/Services/IFileSystemBasedContentRootProvider.cs) **before** the extension method call using the [provided extension methods](src/ViciOne.Ui.MonochromeIcons.Assets/Extensions/IServiceCollectionExtensions.cs#L58-L90).

    > Another option, is to use the [generic variant of the extension method](src/ViciOne.Ui.MonochromeIcons.Assets/Extensions/IServiceCollectionExtensions.cs#L30-46), whitch accepts a `T` specifiying a type to determine the assembly location for locating <c>staticwebassets.runtime.json</c> files.

  - **Blazor WebAssembly** applications should use [`UrlBasedMonochromeIconSvgMarkupProvider`](src/ViciOne.Ui.MonochromeIcons.Assets/Services/UrlBasedMonochromeIconSvgMarkupProvider.cs)

    ``` csharp
    using ViciOne.Ui.MonochromeIcons.Assets.Extensions;

    services.AddUrlBasedMonochromeIconSvgMarkupProvider();
    ```

- Inject [`IMonochromeIconSvgMarkupProvider`](src/ViciOne.Ui.MonochromeIcons.Assets/Services/IMonochromeIconSvgMarkupProvider.cs) and retrieve SVG markup for a specific icon and size

    > Use `GetSvgMarkupAsync()` as the common API. This also works for the URL-based provider used in Blazor WebAssembly.

    ``` csharp
    // Foo.cs

    using ViciOne.Ui.MonochromeIcons.Assets.Services;
    using ViciOne.Ui.MonochromeIcons.Core.Enums;

    public partial class Foo(IMonochromeIconSvgMarkupProvider monochromeIconSvgMarkupProvider)
    {
        private async Task<string?> GetSvgMarkupAsync(MonochromeIconName iconName, MonochromeIconSize iconSize)
            => await monochromeIconSvgMarkupProvider.GetSvgMarkupAsync(iconName, iconSize);
    }
    ```
