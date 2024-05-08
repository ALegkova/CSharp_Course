using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberGame.Classes
{
    public class IntValidator : IValidator
    {
        public bool IsValid(string? data)
        {
            if (String.IsNullOrEmpty(data))
                    return false;
            return int.TryParse(data, out int i);
        }
    }
}
