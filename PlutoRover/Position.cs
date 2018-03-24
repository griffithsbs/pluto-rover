using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover
{
    public class Position
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Direction Direction { get; private set; }

        private Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public static Position Of(int x, int y, Direction direction)
        {
            return new Position(x, y, direction);
        }

        public override string ToString() => $"{X}, {Y}, {Direction}";
    }
}
