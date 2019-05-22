using ConsoleSweep.Interfaces;
using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using ConsoleSweep.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.ViewControlers
{
    public class HelpViewControler : IGameViewControler
    {
        IGameView view;
        public HelpViewControler()
        {
            view = new HelpView();
        }

        public ViewDrawStatus Draw(GameData gameData, PlayerData playerData)
        {
            return view.Draw(gameData, playerData);
        }

        public UpdateStatus ProcessGameKeyPress(ConsoleKey key)
        {
            return key == ConsoleKey.Escape ? UpdateStatus.Close : UpdateStatus.None;
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
