using System;
using System.Collections.Generic;
using System.Linq;

namespace PlutoRover
{
    public class Grid
    {
        private const int STARTING_INDEX = 0;
        private readonly int _width;
        private readonly int _height;
        private readonly IEnumerable<Tuple<int, int>> _obstacleCoordinates;

        /// <summary>
        /// Create a Grid of width squares x height squares, with an obstacle located at
        /// each of the (X, Y) co-ordinates given by obstacleCoordinates
        /// </summary>
        /// <param name="width">The number of columns in the grid</param>
        /// <param name="height">The number of rows in the grid</param>
        /// <param name="obstacleCoordinates">The locations of obstacles in the grid, in (X, Y) pairs</param>
        public Grid(int width, int height, params Tuple<int, int>[] obstacleCoordinates)
        {
            _width = width;
            _height = height;
            _obstacleCoordinates = obstacleCoordinates;
        }

        internal bool HasObstacleAt(Position position)
        {
            return _obstacleCoordinates.FirstOrDefault(t => t.Item1 == position.X && t.Item2 == position.Y) != null;
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
