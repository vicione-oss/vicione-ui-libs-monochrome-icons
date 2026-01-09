# C-Sharp Coding Style

This document contains rules and recommendations specific to this repository on how to write C-Sharp code.

These rules and recommendations override or add to [`common C# code conventions`](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).

## General rules

General rules are ensured by Code Analyzers running in the background based on the configuration applied in [`.globalconfig`](/.globalconfig).

## Is it allowed to intialize a non-nullable field with `default!`?

Using `default!` should be **avoided whenever possible** because it assigns `null` to a member that should never be null.

These assignments could result in possible access violations later on because it disables [Null-state analysis](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references#null-state-analysis) making code compile that should never compile.

``` csharp
public class Foo;

public class Bar
{
    private Foo _this = default!; // initializes non-nullable field with null, not recommended

    private Foo? _that; // prefer nullable type
}
```
