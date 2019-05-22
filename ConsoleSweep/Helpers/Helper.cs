using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleSweep.Helpers
{
    public static class Helper
    {
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return random.Next(min, max);
        }
    }
}
