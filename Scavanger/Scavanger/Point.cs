using System;

namespace Scavanger
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int inX = 0, int inY = 0)
        {
            X = inX;
            Y = inY;
        }

        public override int GetHashCode()
        {
            //Added 0 so that x=11 y=5 (115) is not the sam as x=1 y=15 (115). Now it is(1105 vs. 1015)
            return Convert.ToInt32(X + "" + 0 + Y);
        }

        public override string ToString()
        {
            return "X is:" + X + " Y is:" + Y;
        }
    }
}
