# Getting Started

> [!TIP]
> These packages include Handlebars.Net so you don't need to install anything else.

## Including the addin

At the top of your script, just add the following to install the addin:

```csharp
#addin nuget:?package=Cake.Handlebars
```

## Usage

This addin exposes a few separate aliases for rendering and compilation.

### Rendering

You can use the `RenderTemplate` alias to compile and render a Handlebars template from a `string` in one operation.

```csharp
var template = "Hello {{ name }}!";
var output = RenderTemplate(template, new { name = "World" });
// output is now "Hello World!"
```

To read a template from a local file, use the `RenderTemplateFromFile` alias:

```csharp
//template.hbs has the same template as above
var output = RenderTemplateFromFile("./template.hbs", new { name = "World"});
// output is now "Hello World!"
```

### Compilation

If you're going to be rendering the same template **a lot**, you may want to pre-compile for somewhat faster rendering:

```csharp
var compiled = CompileTemplate("Hello {{ name }}!");
Information(compiled(new { name = "World"}));
Information(compiled(new { name = "Cake"}));
```

There is also a `CompileTemplateFromFile` alias, for reading the template from a file:

```csharp
var compiled = CompileTemplateFromFile("./template.hbs");
Information(compiled(new { name = "World"}));
Information(compiled(new { name = "Cake"}));
```

> [!TIP]
> `Cake.Handlebars` doesn't currently expose the more advanced `Action<TextWriter, string>`-based compilation output. Raise an issue on GitHub if you need this output.