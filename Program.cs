using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Program
    {
        public static void Main()
        {
            Game game = new Game();
            game.GameLoop();
            game.PrintGoodbye();
        }
    }
}
