using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Interfaces
{
    public interface IGameView
    {
        ViewDrawStatus Draw(GameData gameData, PlayerData playerData);
        void ShowError();
        void ShowHit();
    }
}
