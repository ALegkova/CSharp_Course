namespace Delegates.FileFoundHandler
{
    public class FileFounderService
    {        
        FileFounder fileFounder;

        public void Run(string searchDirectory)
        {
            Console.WriteLine("Поиск запущен");
            Console.WriteLine("Для отмены поиска нажмите Q");

            fileFounder = new FileFounder();
            Subscribe();
            fileFounder.FileSearch(searchDirectory);
            Unsubscribe();

            Console.WriteLine("Поиск завершен");
        }

        private void DisplayMessage(object sender, EventArgs e)
        {
            Console.WriteLine($"Найден файл: {((FileArgs)e).FileName}");
            Thread.Sleep(400);

            if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Q)
            {
                Unsubscribe();
                Console.WriteLine("Поиск остановлен");
            }

        }

        private void Subscribe()
        {
            fileFounder.FileFound += DisplayMessage;
        }

        private void Unsubscribe()
        {
            fileFounder.FileFound -= DisplayMessage;
        }
    }

}

