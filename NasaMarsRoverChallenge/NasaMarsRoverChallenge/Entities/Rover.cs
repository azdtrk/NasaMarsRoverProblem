using NasaMarsRoverChallenge.Concrete;

namespace NasaMarsRoverChallenge.Entities
{
    public class Rover
    {
        public Position position { get; set; }
        public char direction { get; set; }

        public Rover(Position position, char direction)
        {
            this.direction = direction;
            this.position = position;
        }
    }
}
