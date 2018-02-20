using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;
using Newtonsoft.Json.Linq;

namespace DynamicClass
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                TypeGenerator typeGenerator = new TypeGenerator(@"C:\Users\kamel30816462\Desktop\DynamicClass.json");
                Type Employee = typeGenerator.GenerateType();
                Console.WriteLine(Employee.GetProperties()[0].Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void InitializeProperties(object employee, Dictionary<string,object> values)
        {
            PropertyInfo[] employeeProperties = employee.GetType().GetProperties();
            int index = 0;
            foreach (PropertyInfo employeeProperty in employeeProperties)
            {
                employeeProperty.SetValue(employee, values[employeeProperty.Name]);
                index++;
            }
        }
    }
}
