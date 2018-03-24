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

        /// <param name="command">The command determining the movement the rover should make</param>
        /// <returns>The rover's position after following the command</returns>
        public string Move(string command)
        {
            switch (command)
            {
                case "F":
                    _position = _position.MoveForward();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return _position.ToString();
        }

        public string ReportPosition()
        {
            return _position.ToString();
        }
    }
}
