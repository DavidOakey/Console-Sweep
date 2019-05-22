using ConsoleSweep.Controlers;
using ConsoleSweep.Models;
using ConsoleSweep.ViewControlers;

namespace ConsoleSweep
{
    class Program
    {
        static void Main(string[] args)
        {
            GameControler.Instance.Run();
        }
    }
}
