using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFileReader;

namespace ArraySummary
{
    public class TestArraySummary<T,K>
    {
        IArraySummary<T, K> arraySummary;
        ILogger logger;
        public TestArraySummary( IArraySummary<T, K> arraySummary, ILogger logger) { 
            this.arraySummary = arraySummary;
            this.logger = logger;
            }

        public void TestSerialSum(T[] arr)
        {
            var stopwatch = Stopwatch.StartNew();
            var elementCount = arr.Length;
            logger.Log($"Старт последовательного суммирования");
            K sum = arraySummary.SerialSum(arr);
            stopwatch.Stop();
            logger.Log($"Сумма элементов массива {sum}");
            logger.Log($"Последовательное суммирование массива из {elementCount} элементов выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");
        }

        public void TestParallelLINQSum(T[] arr, int maxDegreeOfParallelism)
        {
            var stopwatch = Stopwatch.StartNew();
            var elementCount = arr.Length;
            logger.Log($"Старт параллельного суммирования с помощью PLINQ");
            K sum = arraySummary.ParallelLINQSum(arr,maxDegreeOfParallelism);
            stopwatch.Stop();
            logger.Log($"Сумма элементов массива {sum}");
            logger.Log($"Параллельное суммирование массива из {elementCount} элементов с помощью PLINQ с максимальной степенью параллелизма {maxDegreeOfParallelism} выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");
        }

        public void TestParallelThreadSum(T[] arr, int threadCount)
        {
            var stopwatch = Stopwatch.StartNew();
            var elementCount = arr.Length;
            logger.Log($"Старт параллельного суммирования с помощью Thread");
            K sum = arraySummary.ParallelThreadSum(arr, threadCount);
            stopwatch.Stop();
            logger.Log($"Сумма элементов массива {sum}");
            logger.Log($"Параллельное суммирование массива из {elementCount} элементов с помощью Thread в {threadCount} потоков выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");

        }
    }
}
