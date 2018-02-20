using System.IO;
using Newtonsoft.Json.Linq;

namespace DynamicClass
{
    class FileStreamReader :IFileReader
    {
        private readonly string _path;

        public FileStreamReader(string path)
        {
            _path = path;
        }
        public string ReadFile()
        {
            string fileContent;
            using (FileStream classInfoFile = new FileStream(_path, FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(classInfoFile))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

            return fileContent;
        }
    }

}