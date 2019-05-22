using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Helpers
{
    public static class Constants
    {
        public static int DefaultColumns = 10;
        public static int DefaultRows = 8;
        public static int DefaultLives = 3;
        public static int DefaultMines = 10;

        public static char MineChar = '*';
        public static char PlayChar = 'P';

        public static char OpendChar =  ' ';
        public static char PendingChar = ' ';
        public static string StartEndChar = "=>";

        public static int FlashTime = 250;

        public static int MinLives = 1;
        public static int MaxLives = 10;
        public static int MinColumns = 5;
        public static int MaxColumns = 26;
        public static int MinRows = 5;
        public static int MaxRows = 30;
        public static int MinMines = 1;
        public static byte MaxMines = 100;        
    }
}
