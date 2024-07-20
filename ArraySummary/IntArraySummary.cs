using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArraySummary
{
    public class IntArraySummary : IArraySummary<int, Int64>
    {

        /// <summary>
        /// Последовательное вычисление суммы элементов массива
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <returns>long</returns>
        public Int64 SerialSum(int[] arr)
        {
            //Int64 sum = arr.Sum();
            Int64 sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        /// <summary>
        /// Параллельное вычисление суммы элементов массива с помощью PLINQ
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <param name="maxDegreeOfParallelism">Максимальная степень параллелигзма</param>
        /// <returns>long</returns>
        public Int64 ParallelLINQSum(int[] arr, int maxDegreeOfParallelism)
        {
            //Int64 sum = arr.AsParallel().WithDegreeOfParallelism(maxDegreeOfParallelism).Sum(x => (Int64)x);
            Int64 sum = arr.AsParallel().WithDegreeOfParallelism(maxDegreeOfParallelism).Sum();

            return sum;
        }

        /// <summary>
        /// Параллельное вычисление суммы элементов массива с помощью Thread
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <param name="threadCount">Количество потоков</param>
        /// <returns>long</returns>
        public Int64 ParallelThreadSum(int[] arr, int threadCount)
        {
            Int64 sum = 0;
            int elementCount = arr.Count();
            if (threadCount > elementCount)
            {
                threadCount = elementCount;
            }
            int partitionSize = elementCount / threadCount;

            List<Thread> threadList = new List<Thread>();           

            for (int i = 0; i < threadCount; i++)
            {
                int temp = i;
                threadList.Add( new Thread(() =>
                {
                     long tempsum = 0;
                     for (int j = temp * partitionSize; j < ((temp < threadCount - 1) ? (temp + 1) * partitionSize : elementCount); j++)
                     {
                        tempsum += arr[j];
                     }
                     Interlocked.Add(ref sum, tempsum);                    
                }
                ));
                threadList[i].Start();
            }

            for (int i = 0; i < threadCount; i++)
                threadList[i].Join();

            return sum;
        }
       
    }
}


