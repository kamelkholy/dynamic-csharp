using System;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace DynamicClass
{
    class TypeGenerator
    {
        private readonly string _classInfoPath;

        public TypeGenerator(string classInfoPath)
        {
            _classInfoPath = classInfoPath;
        }
        public Type GenerateType()
        {
            string stringClassInfo = LoadClassInfo(_classInfoPath);
            JObject classInfo = JObject.Parse(stringClassInfo);
            string dynamicClass = GenerateClass(classInfo);
            Assembly generatedAssembly = AssemblyGenerator.GenerateAssembly(dynamicClass);
            return generatedAssembly.GetType("DynamicType.Employee");
        }

        private string LoadClassInfo(string path)
        {
            FileStreamReader fileStreamReader = new FileStreamReader(path);
            return fileStreamReader.ReadFile();
        }

        private string GenerateClass(JObject classInfo)
        {
            ClassGenerator classGenerator = new ClassGenerator(classInfo);
            return classGenerator.CreateFullType();
        }
    }
}