using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevilAndAngel
{
    enum Direction
    {
        Right,
        Left,
        Up,
        UpRight,
        UpLeft,
        Down,
        DownRight,
        DownLeft
    }

    struct Point
    {
        public int X;
        public int Y;
    }

    class Angel
    {
        public Point position = new Point();
        public Point previos_pos = new Point();
        public Angel(int x, int y)
        {
            position.X = x;
            position.Y = y;
            previos_pos = position;
        }   
    }
    class Devil
    {
        public Point position = new Point();
        public Point previos_pos = new Point();
    }
    class Game
    {
        private const int Width = 1000;
        private const int Height = 1000;
        public Point screen = new Point();
        public int[,] Field = new int[Width, Height];                
        public Game(int x, int y)
        {
            Field[x,y] = 1;
            screen.X = 10;
            screen.Y = 10;
        }
    }
}
