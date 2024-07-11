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
            int fileCount = fileList.Count;

            FileFounderRun(searchDirectory, fileCount);
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
            int fileCount = fileList.Count();
            await FileFounderRunAsync(searchDirectory, fileCount);
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

            await Task.Run(() =>
            {
                for (int i = 0; i < fileCount; i++)
                {
                    tasks.Add(fileFounder.CalcSpacesInFileAsync(fileList[i]));
                }
            }).ConfigureAwait(false);               

            await Task.WhenAll(tasks).ConfigureAwait(false);

            stopwatch.Stop();
            Console.WriteLine($"выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");
        }


    }
}
