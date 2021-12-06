using NasaMarsRoverChallenge.Entities;

namespace NasaMarsRoverChallenge.Abstract
{
    public interface IRoverController
    {
        Rover rotateRight();
        Rover rotateLeft();
        Rover move();
        void handleCommand(string command);
    }
}
