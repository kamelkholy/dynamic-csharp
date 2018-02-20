using System.Text;
using Newtonsoft.Json.Linq;

namespace DynamicClass
{

    class ClassGenerator
    {
        private readonly JObject _classInfo;
        private readonly StringBuilder _generatedCsCode;
        public ClassGenerator(JObject classInfo)
        {
            _classInfo = classInfo;
            _generatedCsCode = new StringBuilder();
        }
        public string CreateFullType()
        {
            GenerateClassHeader();
            GenerateProperties();
            GenerateClassFooter();
            return _generatedCsCode.ToString();
        }
        private void GenerateClassHeader()
        {
            WriteRefrences();
            _generatedCsCode.Append($"namespace {_classInfo["Namespace"]}\n{{\n");
            _generatedCsCode.Append($"\tpublic class {_classInfo["ClassName"]}\n\t{{\n");
        }
        private void WriteRefrences()
        {
            foreach (JToken refrence in _classInfo["using"])
            {
                _generatedCsCode.Append($"using {refrence["Name"]};\n");
            }
        }
        private void GenerateProperties()
        {
            foreach (JToken property in _classInfo["Properties"])
            {
                _generatedCsCode.Append($"\t\tpublic {property["Type"]} { property["Name"]} {{ get; set; }}\n");
            }
        }
        private void GenerateClassFooter()
        {
            _generatedCsCode.Append("\t}\n}");
        }
    }
}