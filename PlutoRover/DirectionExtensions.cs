using System;

namespace PlutoRover
{
    internal static class DirectionExtensions
    {
        internal static Direction Opposite(this Direction direction)
        {
            switch(direction)
            {
                case Direction.N:
                    return Direction.S;
                case Direction.S:
                    return Direction.N;
                case Direction.E:
                    return Direction.W;
                case Direction.W:
                    return Direction.E;
                default:
                    throw new ArgumentException($"Unrecognised direction {direction}");
            }
        }
    }
}
