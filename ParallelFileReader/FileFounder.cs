using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFileReader
{
    public class FileFounder
    {
        private ILogger logger;

        public FileFounder(ILogger logger)
        {
            this.logger = logger;
        }    

        /// <summary>
        /// Получить список файлов в папке
        /// </summary>
        /// <param name="searchDirectory"></param>
        /// <returns></returns>
        public List<string> GetFiles(string searchDirectory)
        {
            if (!Directory.Exists(searchDirectory))
                throw new DirectoryNotFoundException();
            var files = Directory.GetFiles(searchDirectory, "*.*", SearchOption.AllDirectories);
            List<string> fileList = files.ToList();
            return fileList;
        }

        /// <summary>
        /// Посчитать количество пробелов в файле
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task<long> CalcSpacesInFileAsync(string filePath)
        {
            string fileText = await File.ReadAllTextAsync(filePath);
            long spaceCount = fileText.LongCount(Char.IsWhiteSpace);
            //logger.Log($"Файл: {filePath}, количество пробелов: {spaceCount} \n");
            return spaceCount;
        }

        /// <summary>
        /// Посчитать количество пробелов в файле
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public long CalcSpacesInFile(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            long spaceCount = fileText.LongCount(Char.IsWhiteSpace);
            //logger.Log($"Файл: {filePath}, количество пробелов: {spaceCount} \n");
            return spaceCount;
        }

    }
}
