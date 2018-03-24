using System;

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

        internal Position MoveForward()
        {
            switch (Direction)
            {
                case Direction.N:
                    return new Position(X, Y + 1, Direction);
                case Direction.S:
                    return new Position(X, Y - 1, Direction);
                case Direction.E:
                    return new Position(X + 1, Y, Direction);
                case Direction.W:
                    return new Position(X - 1, Y, Direction);
                default:
                    throw new ArgumentException($"Unrecognised direction {Direction}");
            }
        }

        public override string ToString() => $"{X}, {Y}, {Direction}";
    }
}
