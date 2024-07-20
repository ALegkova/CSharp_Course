using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFileReader
{
    public class TaskFileFounder
    {
        FileFounder fileFounder;

        public TaskFileFounder(FileFounder fileFounder)
        {
            this.fileFounder = fileFounder;            
        }

        public void FileFounderRun(string searchDirectory)
        {
            List<string> fileList = fileFounder.GetFiles(searchDirectory);

            var stopwatch = Stopwatch.StartNew();

            foreach (string file in fileList)
            {
                long spaceCount = fileFounder.CalcSpacesInFile(file);                
            }

            stopwatch.Stop();
            Console.WriteLine($"выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");
        }

        public void FileFounderRun(string searchDirectory, int fileCount)
        { 
            List<string> fileList = fileFounder.GetFiles(searchDirectory);
            if (fileCount > fileList.Count)
            {
                fileCount = fileList.Count;
            }

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < fileCount; i++)
            {
                long spaceCount = fileFounder.CalcSpacesInFile(fileList[i]);
            }
            stopwatch.Stop();
            Console.WriteLine($"выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");
        }

        public async Task FileFounderRunAsync(string searchDirectory)
        {       
            List<string> fileList = fileFounder.GetFiles(searchDirectory);
            List<Task<long>> tasks = new List<Task<long>>();

            var stopwatch = Stopwatch.StartNew();
            
            for (int i = 0; i < fileList.Count; i++)                
            { 
                tasks.Add(fileFounder.CalcSpacesInFileAsync(fileList[i]));             
            }            

            await Task.WhenAll(tasks);

            stopwatch.Stop();
            Console.WriteLine($"выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");
        }

        public async Task FileFounderRunAsync(string searchDirectory, int fileCount)
        {      
            List<string> fileList = fileFounder.GetFiles(searchDirectory);
            List<Task<long>> tasks = new List<Task<long>>();
            
            if (fileCount > fileList.Count)
            {
                fileCount = fileList.Count;
            }

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < fileCount; i++)
            {
                tasks.Add(fileFounder.CalcSpacesInFileAsync(fileList[i]));
            }
            await Task.WhenAll(tasks);

            stopwatch.Stop();
            Console.WriteLine($"выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");
        }


    }
}
