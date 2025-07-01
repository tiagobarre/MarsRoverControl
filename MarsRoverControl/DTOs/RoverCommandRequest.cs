namespace MarsRoverControl.API.DTOs
{
    public class RoverCommandRequest
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public string Direction { get; set; }
        public string Commands { get; set; }

        public RoverCommandRequest() { }

        public RoverCommandRequest(int startX, int startY, string direction, string commands)
        {
            StartX = startX;
            StartY = startY;
            Direction = direction;
            Commands = commands;
        }
    }
}
