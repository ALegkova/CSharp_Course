using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
