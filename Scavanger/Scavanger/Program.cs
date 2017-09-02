using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scavanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Scavanger.Entity.Land land = new Scavanger.Entity.Land(100, 25, "o");
            Scavanger.Graphics game = new Scavanger.Graphics(land);
            Scavanger.Entity.Character Char1 = new Scavanger.Entity.Character("J");
            land.Add(Char1);

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                game.Render();
                game.Update(Console.ReadKey().Key);
            }
        }
    }
}