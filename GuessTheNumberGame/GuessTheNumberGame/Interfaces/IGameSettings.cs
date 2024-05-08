using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Interfaces
{
    internal interface IGameSettings
    {
        int TryCount { get; set; }
        int MinValue { get; set; }
        int MaxValue { get; set; }
    }
}
