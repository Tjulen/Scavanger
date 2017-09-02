using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scavanger
{
    class Graphics
    {
        private Scavanger.Entity.Land land;

        public Graphics(Scavanger.Entity.Land inLand)
        {
            land = inLand;
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < land.coordLand.GetYMax(); y++)
            {
                for (int x = 0; x < land.coordLand.GetXMax(); x++)
                {
                    Console.Write(land.FetchSimbol(x, y));
                }
                Console.WriteLine();
            }
        }

        public void Update()
        {

        }
    }
}
