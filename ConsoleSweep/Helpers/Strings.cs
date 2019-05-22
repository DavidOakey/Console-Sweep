using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Helpers
{
    public static class Strings
    {
        public static string WinningText = "Congratulations you WON!!!  Press (R) to play again.";
        public static string LoosingText = "Bad luck you lose this time!!! Press ® to try again.";
        public static string HeaderText = "Game Info (F1), Settings (F2), Reset(R), Exit(ESC)";
        public static string ScoreLineTextFormater = "Score:{0}            Lives:{1}";

        public static  void PritHelpText()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Close(ESC)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("CONSOLESWEEP");
            Console.WriteLine("------------");
            Console.WriteLine("The aim of the game is to get from the start to the end of the mine field with as lower score as posible.");
            Console.WriteLine("But there are mines along the way! For each mine that you hit you will lose one life.");
            Console.WriteLine("If you run out of lives....");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    YOU LOSE!!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Use WASD or the Arrow keys to move.");
            Console.WriteLine("");
            Console.WriteLine("Its that simple, enjoy.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
