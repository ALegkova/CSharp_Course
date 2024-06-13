namespace Delegates.FileFoundHandler
{
    public class WorkFileFounder
    {        
        FileFounder fileFounder;

        public void Run(string searchDirectory)
        {
            Console.WriteLine("Поиск запущен");
            Console.WriteLine("Для отмены поиска нажмите Q");

            fileFounder = new FileFounder();
            FileFounderSubscribe();
            fileFounder.FileSearch(searchDirectory);
            FileFounderUnsubscribe();

            Console.WriteLine("Поиск завершен");
        }

        private void DisplayMessage(object sender, EventArgs e)
        {
            Console.WriteLine($"Найден файл: {((FileArgs)e).FileName}");
            Thread.Sleep(400);

            if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Q)
            {
                FileFounderUnsubscribe();
                Console.WriteLine("Поиск остановлен");
            }

        }

        private void FileFounderSubscribe()
        {
            fileFounder.FileFound += DisplayMessage;
        }

        private void FileFounderUnsubscribe()
        {
            fileFounder.FileFound -= DisplayMessage;
        }
    }

}

