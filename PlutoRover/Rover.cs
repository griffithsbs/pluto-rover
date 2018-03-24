using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position _position;

        private int _gridWidth;
        private int _gridHeight;

        /// <summary>
        /// Create a new Rover with the given starting position within the given grid.
        /// 
        /// The rover's starting position comprises 0-indexed X and Y co-orindates and a heading
        /// representing one of the four cardinal compass points.
        /// 
        /// The grid's bottom left-hand corner has the co-ordinates (0, 0).
        /// </summary>
        /// <param name="startingPosition">The rover's starting position within the grid</param>
        /// <param name="gridWidth">The number of columns in the grid</param>
        /// <param name="gridHeight">The number of rows in the grid</param>
        public Rover(Position startingPosition, int gridWidth, int gridHeight)
        {
            _position = startingPosition;
            _gridWidth = gridWidth;
            _gridHeight = gridHeight;
        }

        /// <param name="command">The command determining the movement orders for the rover</param>
        /// <returns>The rover's position after following the command</returns>
        public string Move(string command)
        {
            foreach (var c in command)
            {
                ExecuteOrder(c);
            }
            return ReportPosition();
        }

        private void ExecuteOrder(char order)
        {
            switch (order)
            {
                case 'F':
                    _position = _position.MoveForward();
                    CheckBoundsOfGrid();
                    break;
                case 'B':
                    _position = _position.MoveBack();
                    CheckBoundsOfGrid(); // TODO remove repetition?
                    break;
                case 'L':
                    _position = _position.TurnLeft();
                    break;
                case 'R':
                    _position = _position.TurnRight();
                    break;
                default:
                    throw new ArgumentException($"Unrecognised order {order}");
            }
        }

        /// <summary>
        /// Check if the rover has moved off of an edge of the grid. If it has,
        /// wrap its position to the opposite edge of the grid
        /// </summary>
        private void CheckBoundsOfGrid() // TODO this name could probably be improved
        {
            if (_position.Y >= _gridHeight)
            {
                _position = Position.Of(_position.X, 0, _position.Heading);
            }
            if (_position.Y < 0)
            {
                _position = Position.Of(_position.X, _gridHeight - 1, _position.Heading);
            }
            if (_position.X >= _gridWidth)
            {
                _position = Position.Of(0, _position.Y, _position.Heading);
            }
            if (_position.X < 0)
            {
                _position = Position.Of(_gridWidth - 1, _position.Y, _position.Heading);
            }
        }

        public string ReportPosition()
        {
            return _position.ToString();
        }
    }
}
