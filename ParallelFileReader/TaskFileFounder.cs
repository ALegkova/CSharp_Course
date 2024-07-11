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
            ProcessFileList(fileList, fileCount);
        }

        public void FileFounderRun(string searchDirectory, int fileCount)
        { 
            List<string> fileList = fileFounder.GetFiles(searchDirectory);
            if (fileCount > fileList.Count)
            {
                fileCount = fileList.Count;
            }
            ProcessFileList(fileList, fileCount);           
        }

        private void ProcessFileList(List<string> fileList, int fileCount)
        {
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
            int fileCount = fileList.Count();
            await ProcessFileListAsync(fileList, fileCount);
        }

        public async Task FileFounderRunAsync(string searchDirectory, int fileCount)
        {
            List<string> fileList = fileFounder.GetFiles(searchDirectory);
            if (fileCount > fileList.Count)
            {
                fileCount = fileList.Count;
            }
            await ProcessFileListAsync(fileList, fileCount);
        }

        private async Task ProcessFileListAsync(List<string> fileList, int fileCount)
        {
            List<Task<long>> tasks = new List<Task<long>>();
            var stopwatch = Stopwatch.StartNew();

            await Task.Run(() =>
            {
                for (int i = 0; i < fileCount; i++)
                {
                    tasks.Add(fileFounder.CalcSpacesInFileAsync(fileList[i]));
                }
            }).ConfigureAwait(false);               

            await Task.WhenAll(tasks);

            stopwatch.Stop();
            Console.WriteLine($"выполнено за {stopwatch.ElapsedMilliseconds} миллисекунд \n");

        }


    }
}
