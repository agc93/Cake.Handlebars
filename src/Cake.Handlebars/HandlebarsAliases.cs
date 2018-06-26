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
        public static RenderResult RenderTemplate(this ICakeContext ctx, string template, object data) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            var compiled = Hbs.Compile(template);
            return new RenderResult(ctx, compiled(data));
        }

        [CakeMethodAlias]
        public static RenderResult RenderTemplateFromFile(this ICakeContext ctx, FilePath templateFilePath, object data) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            var file = new TemplateFileReader(ctx.FileSystem, templateFilePath);
            return new RenderResult(ctx, file.RenderTemplate(data));
        }

        [CakeMethodAlias]
        public static Func<object, RenderResult> CompileTemplate(this ICakeContext ctx, string template) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            return RenderResult.FromCompiledTemplate(ctx, Hbs.Compile(template));
        }

        [CakeMethodAlias]
        public static Func<object, RenderResult> CompileTemplateFromFile(this ICakeContext ctx, FilePath templateFilePath) {
            ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            var file = new TemplateFileReader(ctx.FileSystem, templateFilePath);
            return RenderResult.FromCompiledTemplate(ctx, file.CompileTemplate());
        }

        
    }
}