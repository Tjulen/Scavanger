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
            Scavanger.Entity.Land land = new Scavanger.Entity.Land(10, 10, "o");
            land.Render();


            Console.ReadKey();
        }

    }
}