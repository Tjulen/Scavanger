using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scavanger
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int inX = 0, int inY = 0)
        {
            X = inX;
            Y = inY;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(X + "" + Y);
        }

        public override string ToString()
        {
            return "X is:" + X + " Y is:" + Y;
        }
    }

    public class CoordinateLand
    {
        private int xMax;
        private int yMax;

        public CoordinateLand(int inXMaX = 0, int inYMaX = 0)
        {
            xMax = inXMaX;
            yMax = inYMaX;
        }

        public bool Collision(Scavanger.Entity.Character inChar, Scavanger.Entity.Land inLand)
        {
            if (inLand.FetchSimbol(inChar.characterCoord.X, inChar.characterCoord.Y) == inLand.landCharDefault)
            {
                return false;
            }
            else if (inLand.coordList.ContainsKey(inChar.characterCoord.GetHashCode()))
            {
                return true;
            }
            else if (inChar.characterCoord.X == xMax)
            {
                return true;
            }
            else if (inChar.characterCoord.Y == yMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetXMax()
        {
            return xMax;
        }
        public int GetYMax()
        {
            return yMax;
        }
    }
}
