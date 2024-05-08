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
        public int TryCount { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public SimpleGameSettings() {
            this.MinValue = 0;
            this.MaxValue = 20;
            this.TryCount = 5;
        }
    }
}
