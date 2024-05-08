using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Interfaces
{
    public interface IGameSettings
    {
        int TryCount { get; init; }
        int MinValue { get; init; }
        int MaxValue { get; init; }
    }
}
