using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace DevilAndAngel
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game play = new Game(525,525);
            Angel angel = new Angel(525,525);
            Devil devil = new Devil();
            Console.WindowHeight = 51;
            Console.WindowWidth = 50;            
            while (!devil.GameWin)
            {
                DrawField(play,angel.position);                
                play.Field[angel.previos_pos.X, angel.previos_pos.Y] = 0;
                do
                {
                    var key = Console.ReadKey(true).Key;
                    angel.position = angel.previos_pos;
                    angel.position = SetDirection(key, angel.position);
                } while (play.Field[angel.position.X, angel.position.Y] == 2);
                play.Field[angel.position.X, angel.position.Y] = 1;
                angel.previos_pos = angel.position;
                DevilRound(play, devil, angel);
            }
        }

        static void DrawField(Game a, Point b)
        {
            int local_x = 0, local_y = 1;
            for (int x = b.X - 25; x < b.X + 25; x++)
            {
                local_y = 1;
                for (int y = b.Y - 25; y < b.Y + 25; y++)
                {
                    Console.SetCursorPosition(local_x, local_y);
                    if (a.Field[x, y] == 0)
                        Console.Write(" ");
                    if (a.Field[x, y] == 1)
                        Console.Write("O");
                    if (a.Field[x, y] == 2)
                        Console.Write("#");
                    local_y++;
                }
                local_x++;
            }
        }
        static void DevilRound(Game play,Devil devil,Angel angel)
        {            
            ConsoleKey key = ConsoleKey.Escape;
            for (int x = angel.position.X - 1; x <= angel.position.X + 1; x++) 
            {
                for (int y = angel.position.Y - 1; y <= angel.position.Y + 1; y++) 
                {
                    if (play.Field[x,y] == 0)
                    {
                        devil.position.X = x;
                        devil.position.Y = y;                        
                    }
                }
            }
          
            play.Field[devil.position.X, devil.position.Y] = 2;
            devil.previos_pos = devil.position;
            bool visited = true;
            do
            {
                DrawField(play,devil.position);
                key = ConsoleKey.F24;
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;
                    visited = false;
                }
                
                devil.previos_pos = devil.position;
                devil.position = SetDirection(key, devil.position);
                play.Field[devil.position.X, devil.position.Y] = 2;
                if (!visited)
                { 
                    play.Field[devil.previos_pos.X, devil.previos_pos.Y] = 0;
                    visited = true;
                }
            } while (key != ConsoleKey.Enter);
            play.Field[devil.position.X, devil.position.Y] = 2;
        }

        static Point SetDirection(ConsoleKey key,Point p)
        {
            if (key == ConsoleKey.W)            
                p.Y--;
            if (key == ConsoleKey.X)
                p.Y++;
            if (key == ConsoleKey.A)
                p.X--;
            if (key == ConsoleKey.D)
                p.X++;

            if (key == ConsoleKey.E)
            {
                p.X++;
                p.Y--;
            }
            if (key == ConsoleKey.Q)
            {
                p.X--;
                p.Y--;
            }
            if (key == ConsoleKey.Z)
            {
                p.X--;
                p.Y++;
            }
            if (key == ConsoleKey.C)
            {
                p.X++;
                p.Y++;
            }
            return p;
        }               
    }
}
