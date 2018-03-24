using System;

namespace PlutoRover
{
    public class Position
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Direction Heading { get; private set; }

        private Position(int x, int y, Direction heading)
        {
            X = x;
            Y = y;
            Heading = heading;
        }

        public static Position Of(int x, int y, Direction heading)
        {
            return new Position(x, y, heading);
        }

        internal Position MoveForward()
        {
            return Move(Heading);
        }

        internal Position MoveBack()
        {
            return Move(Heading.Opposite());
        }

        private Position Move(Direction assumedHeading)
        {
            switch (assumedHeading)
            {
                case Direction.N:
                    return new Position(X, Y + 1, Heading);
                case Direction.S:
                    return new Position(X, Y - 1, Heading);
                case Direction.E:
                    return new Position(X + 1, Y, Heading);
                case Direction.W:
                    return new Position(X - 1, Y, Heading);
                default:
                    throw new ArgumentException($"Unrecognised direction {assumedHeading}");
            }
        }

        public override string ToString() => $"{X}, {Y}, {Heading}";
    }
}
