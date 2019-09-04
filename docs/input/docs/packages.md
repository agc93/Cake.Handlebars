Title: Packages
---

You can include the addin in your script with:

```csharp
#addin nuget:?package=Cake.Handlebars

//or to use the latest development release
#addin nuget:?package=Cake.Handlebars&prerelease
```

The NuGet prerelease packages are automatically built and deployed from the `develop` branch so they can be considered bleeding-edge while the non-prerelease packages will be much more stable.

Versioning is predominantly SemVer-compliant so you can set your version constraints if you're worried about changes.

> These packages include Handlebars.Net so you don't need to install anything else.