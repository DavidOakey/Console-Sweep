using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Interfaces
{
    public interface IGameViewControler
    {
        ViewDrawStatus Draw(GameData gameData, PlayerData playerData);
        UpdateStatus ProcessGameKeyPress(ConsoleKey key);
        void ShowError();
        void ShowHit();
    }
}
