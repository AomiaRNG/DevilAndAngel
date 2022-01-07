using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DevilAndAngel
{
    class Program
    {
        struct Point
        {
            public int X;
            public int Y;
        }

        static void Main(string[] args)
        {
            Point a = new Point();
            while (true)
            {
                Angel(a);
                a.X = Console.WindowWidth / 2;
                a.Y = Console.WindowHeight / 2;
                Console.ReadKey(true);
            }
        }

        static void Angel(Point a)
        {
            Console.SetCursorPosition(a.X,a.Y);
            Console.WriteLine(" ");

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("O");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
        }
    }
}
