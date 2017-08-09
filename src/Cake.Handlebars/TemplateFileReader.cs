using System;
using System.IO;
using Cake.Core.IO;
using Hbs = HandlebarsDotNet.Handlebars;

namespace Cake.Handlebars
{
    public class TemplateFileReader
    {
        private readonly FilePath _filePath;
        private readonly IFileSystem _fs;
        private readonly IFile _file;

        public TemplateFileReader(IFileSystem fs, FilePath templateFilePath) {
            if (!_fs.Exist(templateFilePath)) throw new FileNotFoundException("Could not find requested template file", templateFilePath.FullPath);
            _file = fs.GetFile(templateFilePath);
        }

        public string RenderTemplate(object data) {
            var compiled = Hbs.Compile(ReadTemplate());
            return compiled(data);
        }

        public string ReadTemplate() {
            using (var reader = new StreamReader(_file.OpenRead())) {
                var template = reader.ReadToEnd();
                return template;
            }
        }

        public Func<object, string> CompileTemplate() {
            var template = ReadTemplate();
            return Hbs.Compile(template);
        }

        public Action<TextWriter, string> CompileTemplateToWriter() {
            using (var reader = new StreamReader(_file.OpenRead())) {
                return Hbs.Compile(reader);
            }
        }
    }
}