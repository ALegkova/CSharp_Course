using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    internal class PropertiesGameSettings : IGameSettings
    {        
        public int TryCount { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public PropertiesGameSettings()
        {            
            this.TryCount = Properties.Settings.Default.TryCount;
            this.MinValue = Properties.Settings.Default.MinValue;
            this.MaxValue = Properties.Settings.Default.MaxValue;
        }
    }
}
