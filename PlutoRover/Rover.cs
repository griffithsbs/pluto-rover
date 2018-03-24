using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position _position;
        private Grid _grid;

        private Position _encounteredObstaclePosition = null;

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
                bool hasEncounteredObstacle = ExecuteOrder(c);
                if(hasEncounteredObstacle)
                {
                    break;
                }
            }
            return ReportPosition();
        }

        /// <summary>
        /// Execute the given order to update the rover's position
        /// </summary>
        /// <param name="order">The order: F, B, L, or R</param>
        /// <returns>
        /// True if an obstacle was detected, or false if no obstacle 
        /// was detected and the order was successfully executed
        /// </returns>
        private bool ExecuteOrder(char order)
        {
            Position originalPosition = _position;
            switch (order)
            {
                // TODO remove repetition from implementation of F and B orders
                case 'F':
                    _position = _position.MoveForward();
                    _position = _grid.Wrap(_position);
                    if(_grid.HasObstacleAt(_position))
                    {
                        _encounteredObstaclePosition = _position;
                        _position = originalPosition;
                        return true;
                    }
                    break;
                case 'B':
                    _position = _position.MoveBack();
                    _position = _grid.Wrap(_position);
                    if (_grid.HasObstacleAt(_position))
                    {
                        _encounteredObstaclePosition = _position;
                        _position = originalPosition;
                        return true;
                    }
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
            return false;
        }

        public string ReportPosition()
        {
            string positionReport = _position.ToString();
            if(_encounteredObstaclePosition != null)
            {
                positionReport = $"{positionReport}. {ReportEncounteredObstacle()}";
            }
            return positionReport;
        }

        private string ReportEncounteredObstacle()
        {
            string obstacleReport = $"Obstacle found at ({_encounteredObstaclePosition.X}, {_encounteredObstaclePosition.Y})";
            _encounteredObstaclePosition = null;
            return obstacleReport;
        }
    }
}
