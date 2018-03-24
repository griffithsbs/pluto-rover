namespace PlutoRover
{
    public class Rover
    {
        private Position _position;

        public Rover(Position startingPosition)
        {
            _position = startingPosition;
        }

        public string ReportPosition()
        {
            return _position.ToString();
        }
    }
}
