using System;

namespace PlutoRover
{
    public class Rover
    {
        private Position _position;

        public Rover(Position startingPosition)
        {
            _position = startingPosition;
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

        private void ExecuteOrder(char command)
        {
            switch (command)
            {
                case 'F':
                    _position = _position.MoveForward();
                    break;
                case 'B':
                    _position = _position.MoveBack();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public string ReportPosition()
        {
            return _position.ToString();
        }
    }
}
