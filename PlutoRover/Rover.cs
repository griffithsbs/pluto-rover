using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position _position;
        private Grid _grid;

        /// <summary>
        /// Create a new Rover with the given starting position within the given grid.
        /// </summary>
        /// <param name="startingPosition">The starting position (and heading) within the given grid</param>
        /// <param name="grid">The grid of squares in which the rover is located</param>
        public Rover(Position startingPosition, Grid grid)
        {
            _position = startingPosition;
            _grid = grid;
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
                    _position = _grid.Wrap(_position);
                    break;
                case 'B':
                    _position = _position.MoveBack();
                    _position = _grid.Wrap(_position);
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

        public string ReportPosition()
        {
            return _position.ToString();
        }
    }
}
