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
            Scavanger.Entity.Land land = new Scavanger.Entity.Land(10, 1, "I");
            //Scavanger.Graphics game = new Scavanger.Graphics(land);
            land.Render();
            Scavanger.Entity.Character c = new Scavanger.Entity.Character("Christ");
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.GetHashCode());
            Console.WriteLine(land.GetHashCode());
            Console.WriteLine(land.ToString());

            //game.Render();
            Console.ReadKey();
        }

    }
}