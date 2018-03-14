using System;
using System.IO;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Handlebars
{
    public class RenderResult 
    {
        private ICakeContext Context {get;}
        private string Content {get;set;}
        internal RenderResult(ICakeContext ctx, string content)
        {
            Context = ctx;
            Content = content;
        }

        public static implicit operator string(RenderResult result) {
            return result.Content;
        }

        public override string ToString() {
            return Content;
        }
        
        internal static Func<object, RenderResult> FromCompiledTemplate(ICakeContext ctx, Func<object, string> compiled) {
            return data => new RenderResult(ctx, compiled(data));
        }

        public RenderResult WriteToFile(FilePath targetPath) {
            using (var writer = new StreamWriter(Context.FileSystem.GetFile(targetPath).OpenWrite())) {
                writer.Write(Content);
            }
            return this;
        }
    }
}