﻿using System;

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

        internal static Direction TurnClockwise(this Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    return Direction.E;
                case Direction.E:
                    return Direction.S;
                case Direction.S:
                    return Direction.W;
                case Direction.W:
                    return Direction.N;
                default:
                    throw new ArgumentException($"Unrecognised direction {direction}");
            }
        }

        internal static Direction TurnAnticlockwise(this Direction direction)
        {
            // TODO we could implement this by turning clockwise three times.
            // The way we're doing it is more verbose but potentially much more efficient,
            // depending on how the rover hardware implements the turn operation
            switch (direction)
            {
                case Direction.N:
                    return Direction.W;
                case Direction.E:
                    return Direction.N;
                case Direction.S:
                    return Direction.E;
                case Direction.W:
                    return Direction.S;
                default:
                    throw new ArgumentException($"Unrecognised direction {direction}");
            }
        }

    }
}
