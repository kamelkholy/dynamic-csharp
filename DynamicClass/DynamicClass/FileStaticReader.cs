using System.IO;

namespace DynamicClass
{
    class FileStaticReader : IFileReader
    {
        private readonly string _path;

        public FileStaticReader(string path)
        {
            _path = path;
        }
        public string ReadFile()
        {
            return File.ReadAllText(_path);
        }
    }
}