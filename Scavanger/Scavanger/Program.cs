using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scavanger
{
    class Program
    {
        public static bool Terminate = false;

        static void Main(string[] args)
        {
            System.Threading.Thread MainThread = new System.Threading.Thread(() => StartProcess(90, 25, "o"));
            System.Threading.Thread ConsoleKeyEvent = new System.Threading.Thread(new System.Threading.ThreadStart(KeyboardEvent));
            MainThread.Start();
            ConsoleKeyEvent.Start();

            while (true)
            {
                if (Terminate)
                {
                    Console.Clear();
                    Console.WriteLine("Terminating process!");
                    MainThread.Abort();
                    ConsoleKeyEvent.Abort();
                    System.Threading.Thread.Sleep(1000);
                    return;
                }
            }
        }

        public static void KeyboardEvent()
        {
            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Terminate = true;
                }
            } while (true);
        }

        public static void StartProcess(int x, int y, string str)
        {
            Scavanger.Entity.Land land = new Scavanger.Entity.Land(x, y, str);
            Scavanger.Graphics game = new Scavanger.Graphics(land);
            while (true)
            {
                game.Render();
                //game.Update();
            }
        }
    }
}