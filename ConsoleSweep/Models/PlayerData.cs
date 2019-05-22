using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Models
{
    public class PlayerData
    {
        public Position CurrentPosition { get; set; }
        public int Lives { get; internal set; }
        public int Moves { get; internal set; }
    }
}
