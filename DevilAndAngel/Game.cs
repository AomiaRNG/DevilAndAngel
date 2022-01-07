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
    class Game
    {
        private const int Width = 1000;
        private const int Height = 1000;
        public int[,] Field = new int[Width, Height];
    }
}
