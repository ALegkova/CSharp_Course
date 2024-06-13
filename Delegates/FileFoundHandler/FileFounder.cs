using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.FileFoundHandler
{
    public class FileFounder
    {
        public delegate void FileFoundEventHandler(object sender, FileArgs e);
        public event FileFoundEventHandler FileFound;

        public void FileSearch(string searchDirectory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(searchDirectory);
            if (directoryInfo == null) throw new DirectoryNotFoundException();
            foreach (FileInfo fileInfo in directoryInfo.EnumerateFiles())
            {
                FileFound?.Invoke(this, new FileArgs(fileInfo.Name));             
            }
        }

    }
}
