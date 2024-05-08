﻿using GuessTheNumberGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuessTheNumberGame.Classes
{
    internal class Game
    {
        private IInputReader inputReader;
        private IPrinter printer;
        private IGameSettings settings;
        private IValidator validator;
        private int numberToGuess;

        public Game(IInputReader inputReader, IPrinter printer, IGameSettings settings, IValidator validator)
        {
            this.inputReader = inputReader;
            this.printer = printer;
            this.settings = settings;
            this.validator = validator;
        }

        public void GameInit()
        {
            Random random = new Random();
            numberToGuess = random.Next(settings.MinValue, settings.MaxValue + 1);
            printer.Print($"Загадано число от {settings.MinValue} до {settings.MaxValue}. Попробуйте угадать его за {settings.TryCount} попыток.");
        }

        public void GameProcess()
        {
            int usedTryCount = 0;
            string? inputValue;
            ValidationResult validationResult = ValidationResult.NotValid;
            GameResult gameResult = GameResult.Lose;

            while ((usedTryCount<settings.TryCount)&&(validationResult!=ValidationResult.Equal))
            {
                inputValue = inputReader.GetInputData();
                validationResult = CheckUserInput(inputValue);
                PrintValidationResult(validationResult);
                if (validationResult==ValidationResult.Equal)
                    gameResult = GameResult.Win;
                usedTryCount++;
            }

            PrintGameResult(gameResult);
        }

        private ValidationResult CheckUserInput(string? userInput)
        {
            if (!validator.IsValid(userInput))
                return (ValidationResult.NotValid);
            int.TryParse(userInput, out int userInputNumber);
            if (userInputNumber < numberToGuess)
            {
                return (ValidationResult.Less);
            }
            else if (userInputNumber > numberToGuess)
            {
                return (ValidationResult.More);
            }
            else
            {
                return (ValidationResult.Equal);
            }
        }

        private void PrintValidationResult(ValidationResult result)
        {
            switch (result)
            {
                case ValidationResult.Less:
                    printer.Print("Введенное число меньше загаданного");
                    break;
                case ValidationResult.More:
                    printer.Print("Введенное число больше загаданного");
                    break;
                case ValidationResult.NotValid:
                    printer.Print("Введенные данные некорректны");
                    break;
            }

        }

        private void PrintGameResult(GameResult result)
        {
            switch (result)
            {
                case GameResult.Win:
                    printer.Print("Поздравляем! Вы угадали загаденное число!");
                    break;
                case GameResult.Lose:
                    printer.Print($"К сожалению, попытки закончились. Было загадано число {numberToGuess}");
                    break; 
            }

        }
    }
}
