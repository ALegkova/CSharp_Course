using GuessTheNumberGame.Classes;
using GuessTheNumberGame.Interfaces;

namespace GuessTheNumber.Interfaces;

public class Program
{
    static void Main(string[] args)
    {
        IInputReader inputReader = new ConsoleInputReader();
        IPrinter printer = new ConsolePrinter();
        IGameSettings settings = new PropertiesGameSettings();
        IValidator validator = new IntValidator();

        Game game = new Game(inputReader, printer, settings, validator);

        game.GameInit();
        game.GameProcess();
    }
}