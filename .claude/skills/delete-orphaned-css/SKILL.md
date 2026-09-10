---
name: delete-orphaned-css
description: >-
  Find and delete orphaned Blazor scoped Sass sources and generated CSS files—
  `*.razor.scss` or `*.razor.css` files with no adjacent `.razor` component. Use
  when a build reports BLAZOR102, or when asked to remove orphaned, dangling, or
  unused scoped styles.
---

# Delete orphaned scoped styles

Remove scoped Sass sources and generated CSS files that no longer have a
matching Razor component.

This repository uses `AspNetCore.SassCompiler`. A `Foo.razor.scss` source file
produces `Foo.razor.css`, and Blazor expects both to correspond to
`Foo.razor`. Deleting only the generated CSS is insufficient when the orphaned
Sass source remains because the next build recreates the CSS and BLAZOR102.

## Workflow

1. Scan `src` and `samples` for `*.razor.scss` and `*.razor.css` files whose
   adjacent `.razor` component does not exist. Exclude build output directories:

   ```powershell
   $sourceRoots = @('src', 'samples') |
     Where-Object { Test-Path -LiteralPath $_ -PathType Container }

   Get-ChildItem -Path $sourceRoots -Recurse -File |
     Where-Object {
       $_.Name -like '*.razor.scss' -or $_.Name -like '*.razor.css'
     } |
     Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' } |
     Where-Object {
       $componentPath = $_.FullName -replace '\.(scss|css)$', ''
       -not (Test-Path -LiteralPath $componentPath -PathType Leaf)
     } |
     ForEach-Object { $_.FullName }
   ```

2. Group results by their expected `.razor` component. Remove the orphaned
   `*.razor.scss` source and its generated `*.razor.css` output when present. If
   only a stale generated CSS file exists, remove that file.
3. Run the scan again and confirm it reports no orphaned scoped style files.
4. Build `ViciOne.MonochromeIcons.slnx` and confirm that BLAZOR102 is gone and no
   other build failure was introduced.

## Scope discipline

- Never remove a scoped style file whose adjacent `.razor` component exists.
- Do not remove files from `bin` or `obj`; those directories are build output and
  are outside this cleanup.
- Treat `*.razor.scss` as the maintained source and `*.razor.css` as generated
  output.
