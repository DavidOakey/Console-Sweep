using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Models
{
    public class GameSettings
    {
        public int Lives { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Mines { get; set; }
    }
}
