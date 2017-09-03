using System;

namespace Scavanger
{
    public class Entity
    {
        public class Character
        {
            public ConsoleColor color;
            private string name;
            public Point point = new Point();

            public Character(string inName, ConsoleColor inColor, int pointXIn = 0, int pointYIn = 0)
            {
                name = inName;
                color = inColor;
                point.X = pointXIn;
                point.Y = pointYIn;
            }

            public string GetName()
            {
                return name;
            }
        }
    }
}
