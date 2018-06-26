# Cake.Handlebars

## A simple Cake addin for rendering and compiling Handlebars templates

## Installation

In your build script, add the following directive to install Cake.Handlebars:

```cake
#addin nuget:?package=Cake.Handlebars
```

## Usage

This addin exposes four aliases for rendering and compiling, from either `string` or input file.

```csharp
var result = RenderTemplate("Hello {{ name }}!", new { name = "World"});
result = RenderTemplateFromFile("./template.hbs", new { name = "World"});
```

```csharp
var compiled = CompileTemplate("Hello {{ name}}!");
var result = compiled(new { name = "World"});

var template = CompileTemplateFromFile("./template.hbs");
result = template(new { name = "World"});
```

### Writing to file

While the above examples will work anywhere you want the `string` output, you can also write directly to a file using the fluent `WriteToFile` method:

```csharp
RenderTemplate("Hello {{ name }}!", new { name = "World"}).WriteToFile("./output.txt");
```

```csharp
var compiled = CompileTemplate("Hello {{ name}}!");
var result = compiled(new { name = "World"}).WriteToFile("./output.txt");
```