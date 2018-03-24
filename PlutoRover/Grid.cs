using System;

namespace PlutoRover
{
    public class Grid
    {
        private const int STARTING_INDEX = 0;
        private readonly int _width;
        private readonly int _height;

        /// <summary>
        /// Create a Grid of width squares x height squares
        /// </summary>
        /// <param name="width">The number of columns in the grid</param>
        /// <param name="height">The number of rows in the grid</param>
        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Check if the given position is beyond an edge of the grid. If it is,
        /// return a new position at the start of the opposite edge.
        /// </summary>
        internal Position Wrap(Position position)
        {
            if (IsBeyondNorthBound(position.Y))
            {
                return Position.Of(position.X, 0, position.Heading);
            }
            if (IsBeyondSouthBound(position.Y))
            {
                return Position.Of(position.X, _height - 1, position.Heading);
            }
            if (IsBeyondEastBound(position.X))
            {
                return Position.Of(STARTING_INDEX, position.Y, position.Heading);
            }
            if (IsBeyondWestBound(position.X))
            {
                return Position.Of(_width - 1, position.Y, position.Heading);
            }
            return position;
        }

        private bool IsBeyondNorthBound(int yPosition)
        {
            return yPosition >= _height;
        }

        private bool IsBeyondSouthBound(int yPosition)
        {
            return yPosition < STARTING_INDEX;
        }

        private bool IsBeyondEastBound(int xPosition)
        {
            return xPosition >= _width;
        }

        private bool IsBeyondWestBound(int xPosition)
        {
            return xPosition < STARTING_INDEX;
        }
    }
}
