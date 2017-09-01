using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scavanger
{
    public class Entity
    {
        public class Character
        {
            private string name;
            public Coordinate characterCoord = new Coordinate();

            public Character(string inName)
            {
                name = inName;
            }

            public string GetName()
            {
                return name;
            }
        }

        public class Land
        {
            public List<Character> charList = new List<Character>();
            public Dictionary<int, string> coordList = new Dictionary<int, string>();
            public CoordinateLand coordLand;

            public readonly string landCharDefault;

            public Land(int xMax, int yMax, string inLandCharDefault)
            {
                coordLand = new CoordinateLand(xMax, yMax);
                landCharDefault = inLandCharDefault;
                Init();
            }

            public void Init()
            {
                for (int y = 0; y < coordLand.GetYMax(); y++)
                {
                    for (int x = 0; x < coordLand.GetXMax(); x++)
                    {
                        Scavanger.Coordinate coord = new Scavanger.Coordinate(x, y);
                        coordList.Add(coord.GetHashCode(), landCharDefault);
                    }
                }
            }

            public void Render()
            {
                Console.Clear();
                for (int y = 0; y < coordLand.GetYMax(); y++)
                {
                    for (int x = 0; x < coordLand.GetXMax(); x++)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(this.FetchSimbol(x, y));
                    }
                    Console.WriteLine();
                }
            }

            public bool Add(Character inChar)
            {
                if (coordLand.Collision(inChar, this))
                {
                    return false;
                }
                coordList.Add(key: inChar.characterCoord.GetHashCode(), value: inChar.GetName());
                return true;
            }

            public string FetchSimbol(int coordInX, int coordInY)
            {
                Coordinate coord = new Coordinate(coordInX, coordInY);
                coordList.TryGetValue(coord.GetHashCode(), out string value);
                return value;
            }
        }
    }
}
