using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySummary
{
    public interface IArraySummary<T,K>
    {
        /// <summary>
        /// Последовательное вычисление суммы элементов массива
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <returns>long</returns>
        K SerialSum(T[] arr);

        /// <summary>
        /// Параллельное вычисление суммы элементов массива с помощью PLINQ
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <param name="maxDegreeOfParallelism">Максимальная степень параллелигзма</param>
        /// <returns>long</returns>
        K ParallelLINQSum(T[] arr, int maxDegreeOfParallelism);

        /// <summary>
        /// Параллельное вычисление суммы элементов массива с помощью Thread
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <param name="threadCount">Количество потоков</param>
        /// <returns>long</returns>
        K ParallelThreadSum(T[] arr, int threadCount);
    }
}
