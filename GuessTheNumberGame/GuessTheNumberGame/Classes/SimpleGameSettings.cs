using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    internal class SimpleGameSettings : IGameSettings
    {
        public int TryCount { get; init; }
        public int MinValue { get; init; }
        public int MaxValue { get; init; }

        public SimpleGameSettings() {
            this.MinValue = 0;
            this.MaxValue = 20;
            this.TryCount = 5;
        }
    }
}
