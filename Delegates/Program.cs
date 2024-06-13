using Delegates.EnumerableExtention;
using Delegates.FileFoundHandler;
using System;
using System.Threading;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Поиск максимального элемента коллекции
            TestEnumerableExtention testEnumerableExtention = new TestEnumerableExtention();
            testEnumerableExtention.TestRun();

            Console.WriteLine();

            // Поиск файлов
            FileFounderService fileFounderService = new FileFounderService();
            fileFounderService.Run(AppDomain.CurrentDomain.BaseDirectory);

            Console.ReadKey();
        }
    }
}
