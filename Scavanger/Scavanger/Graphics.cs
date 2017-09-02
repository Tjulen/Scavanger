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
            for (int y = 0; y <= land.coordLand.GetYMax(); y++)
            {
                for (int x = 0; x <= land.coordLand.GetXMax(); x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(land.FetchSimbol(x, y));
                }
                Console.WriteLine();
            }
        }

        public void Update(ConsoleKey keyIn)
        {
            Scavanger.Entity.Character character = land.charList.ElementAt(0);
            switch (keyIn)
            {
                case ConsoleKey.W:
                    character.characterCoord.Y += 1;
                    break;
                case ConsoleKey.S:
                    character.characterCoord.Y -= 1;
                    break;
                case ConsoleKey.A:
                    character.characterCoord.X -= 1;
                    break;
                case ConsoleKey.D:
                    character.characterCoord.X += 1;
                    break;
            }
        }
    }
}
