using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class PropertiesGameSettings : IGameSettings
    {        
        public int TryCount { get; init; }
        public int MinValue { get; init; }
        public int MaxValue { get; init; }

        public PropertiesGameSettings()
        {            
            this.TryCount = Properties.Settings.Default.TryCount;
            this.MinValue = Properties.Settings.Default.MinValue;
            this.MaxValue = Properties.Settings.Default.MaxValue;
        }
    }
}
