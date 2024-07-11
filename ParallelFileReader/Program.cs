using System;
using System.Threading;
using TaskFileReader;

namespace Delegates
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string searchDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\TestFiles";

            ILogger logger = new ConsoleLogger();
            FileFounder fileFounder = new FileFounder(logger);
            TaskFileFounder taskFileFounder = new TaskFileFounder(fileFounder);
            //Прочитать все файлы последовательно
            //taskFileFounder.FileFounderRun(searchDirectory);
            //Прочитать три файла последовательно
            //taskFileFounder.FileFounderRun(searchDirectory,3);
            //Прочитать все файлы параллельно
            //await taskFileFounder.FileFounderRunAsync(searchDirectory);
            //Прочитать 3 файла параллельно
            //await taskFileFounder.FileFounderRunAsync(searchDirectory, 3);
        }       
    }
}


