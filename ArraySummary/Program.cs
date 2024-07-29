using System;
using System.Threading;
using TaskFileReader;

namespace ArraySummary
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementCount = 100_000_000;
            int threadCount = 5;

            int[] arr = new int[elementCount];           
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1;
            }

            IArraySummary<int, Int64> intArraySummary = new IntArraySummary();
            ILogger logger = new ConsoleLogger();

            TestArraySummary<int, Int64> testArraySummary = new TestArraySummary<int, Int64>(intArraySummary, logger);
            testArraySummary.TestSerialSum(arr);
            testArraySummary.TestParallelLINQSum(arr, threadCount);
            testArraySummary.TestParallelThreadSum(arr, threadCount);
        }
    }
}
