using ConsoleSweep.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Models
{
    public class GameData
    {
        public int Score { get; set; }
        public ScreenDisplayData CurrentScreenDisplayData { get; set; }
        public GameStatus Status { get; set; }

    }
}
