using System;
using System.IO;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using HandlebarsDotNet;
using Hbs = HandlebarsDotNet.Handlebars;

namespace Cake.Handlebars
{
    [CakeAliasCategory("Handlebars")]
    [CakeNamespaceImport("HandlebarsDotNet")]
    public static class HandlebarsAliases
    {
        [CakeMethodAlias]
        public static string RenderTemplate(this ICakeContext ctx, string template, object data) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            var compiled = Hbs.Compile(template);
            return compiled(data);
        }

        [CakeMethodAlias]
        public static string RenderTemplateFromFile(this ICakeContext ctx, FilePath templateFilePath, object data) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            var file = new TemplateFileReader(ctx.FileSystem, templateFilePath);
            return file.RenderTemplate(data);
        }

        [CakeMethodAlias]
        public static Func<object, string> CompileTemplate(this ICakeContext ctx, string template) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            return Hbs.Compile(template);
        }

        [CakeMethodAlias]
        public static Func<object, string> CompileTemplateFromFile(this ICakeContext ctx, FilePath templateFilePath) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            var file = new TemplateFileReader(ctx.FileSystem, templateFilePath);
            return file.CompileTemplate();
        }
    }
}