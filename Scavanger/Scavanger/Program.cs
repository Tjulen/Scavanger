using System;

namespace Scavanger
{
    class Program
    {
        const ConsoleColor PLAYER_COLOR = ConsoleColor.Black;
        const ConsoleColor BACKGROUND_COLOR = ConsoleColor.DarkGreen;
        const int SPEED = 2;

        static Point Player { get; set; }

        static void Main(string[] args)
        {
            InitWorld(0, 0);

            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        MovePlayer(0, -SPEED);
                        break;

                    case ConsoleKey.S:
                        MovePlayer(0, SPEED);
                        break;

                    case ConsoleKey.A:
                        MovePlayer(-SPEED, 0);
                        break;

                    case ConsoleKey.D:
                        MovePlayer(SPEED, 0);
                        break;
                }
            }
        }

        static void MovePlayer(int inX, int inY)
        {
            Point newPoint = new Point
            {
                X = Player.X + inX,
                Y = Player.Y + inY
            };

            if (CanMove(newPoint))
            {
                RemovePlayer();
                Player.X = Player.X + inX;
                Player.Y = Player.X + inY;

                Console.SetCursorPosition(newPoint.X, newPoint.Y);
                Console.BackgroundColor = PLAYER_COLOR;
                Console.WriteLine(" ");
                Player = newPoint;
            }
        }

        static bool CanMove(Point point)
        {
            if (point.X < 0 || point.X >= Console.WindowWidth)
                return false;
            if (point.Y < 0 || point.Y >= Console.WindowHeight)
                return false;
            return true;
        }

        static void RemovePlayer()
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.SetCursorPosition(Player.X, Player.Y);
            Console.WriteLine(" ");
        }

        static void InitWorld(int inX, int inY)
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.Clear();

            Player = new Point { X = inX, Y = inY };
        }


        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}