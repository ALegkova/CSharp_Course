using System;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Reflection;
using Serializer.Classes;
using Serializer.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Serializer
{
    public class Program
    {
        static void Main(string[] args)
        {
            F testClass = F.GetTestClass();
            int iterationCount = 10000;

            TestSerializer testCSVSerializer = new TestSerializer(iterationCount, new CSVSerializer(",",Environment.NewLine));            
            Console.WriteLine(testCSVSerializer.TestRunSerializing(testClass));

            TestSerializer testJSONSerializer = new TestSerializer(iterationCount, new JSONSerializer());
            Console.WriteLine(testJSONSerializer.TestRunSerializing(testClass));       

        }
    }
}
