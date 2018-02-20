using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace DynamicClass
{
    class AssemblyGenerator
    {
        public static Assembly GenerateAssembly(string dynamicClass)
        {
            CompilerResults compilingResults = CompileCode(dynamicClass, "DynamicType.dll");
            Assembly generatedAssembly = compilingResults.CompiledAssembly;
            return generatedAssembly;
        }

        private static CompilerResults CompileCode(string code, string assemblyName)
        {
            CompilerParameters parameters = InitializeCompilerParameters(assemblyName);
            CSharpCodeProvider provider = new CSharpCodeProvider();
            return provider.CompileAssemblyFromSource(parameters, code);
        }

        private static CompilerParameters InitializeCompilerParameters(string assemblyName)
        {
            return new CompilerParameters
            {
                GenerateExecutable = false,
                OutputAssembly = assemblyName
            };
        }
    }
}