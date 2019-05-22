using ConsoleSweep.Interfaces;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Views
{
    public class HelpView : IGameView
    {
        public ViewDrawStatus Draw(GameData gameData, PlayerData playerData)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Helpers.Strings.PritHelpText();

            return ViewDrawStatus.Ok;
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }

        public void ShowHit()
        {
            throw new NotImplementedException();
        }
    }
}
