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
        public static string RenderTemplate(this ICakeContext ctx, string template) {
            var compiled = Hbs.Compile(template);
            return compiled(new {});
        }

        [CakeMethodAlias]
        public static string RenderTemplate(this ICakeContext ctx, string template, object data) {
            var compiled = Hbs.Compile(template);
            return compiled(data);
        }

        [CakeMethodAlias]
        public static Func<object, string> CompileTemplate(this ICakeContext ctx, string template) {
            return Hbs.Compile(template);
        }

        [CakeMethodAlias]
        public static Action<TextWriter, string> CompileTemplate(this ICakeContext ctx, FilePath templateFilePath) {
            var templateFile = ctx.FileSystem.GetFile(templateFilePath);
            var reader = new StreamReader(templateFile.OpenRead());
            return Hbs.Compile(reader);
        }
    }
}