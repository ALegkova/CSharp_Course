using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public abstract class GeneralGame
    {
        private IInputReader inputReader;
        private IPrinter printer;
        private IGameSettings settings;
        private IValidator validator;

        public void Run()
        {
            GameInit();
            GameProcess();           
        }

        public abstract void GameInit();
        public abstract void GameProcess();
    }
}
