using ConsoleSweep.Models;
using ConsoleSweep.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Interfaces
{
    public interface IPlayerControler
    {
        UpdateStatus Move(PlayerMoveType move, PlayerData playerData, GameSettings settings);
    }
}
