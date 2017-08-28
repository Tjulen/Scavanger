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

            public override int GetHashCode()
            {
                return Convert.ToInt32(characterCoord.X + "" + characterCoord.Y);
            }

            public override string ToString()
            {
                return ("Name:" + name + " X:" + characterCoord.X + " Y:" + characterCoord.Y);
            }
        }

        public class Land
        {
            public Dictionary<Coordinate, string> coordList = new Dictionary<Coordinate, string>();
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
                        coordList.Add(coord, landCharDefault);
                        //coordList.TryGetValue(coord, out string val);
                        //Console.WriteLine(val);
                    }
                }
            }

            public void Render()
            {
                //Console.Clear();
                for (int y = 0; y < coordLand.GetYMax(); y++)
                {
                    for (int x = 0; x < coordLand.GetXMax(); x++)
                    {
                        Console.WriteLine(coordList.ContainsKey(new Coordinate(x, y)));
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
                coordList.Add(key: inChar.characterCoord, value: inChar.GetName());
                return true;
            }

            public string FetchSimbol(int coordInX, int coordInY)
            {
                Coordinate coord = new Coordinate(coordInX, coordInY);
                if (coordList.ContainsKey(coord))
                {
                    Console.WriteLine("coord found!");
                }
                coordList.TryGetValue(coord, out string value);
                Console.WriteLine("X: " + coord.X);
                Console.WriteLine("Y: " + coord.Y);
                Console.WriteLine(value);
                return value;
            }
        }
    }
}
