using NasaMarsRoverChallenge.Abstract;
using NasaMarsRoverChallenge.Entities;
using NasaMarsRoverChallenge.Exceptions;
using System;

namespace NasaMarsRoverChallenge.Concrete
{
    public enum Directions
    {
        North = 'N',
        South = 'S',
        East = 'E',
        West = 'W'
    }

    public enum Commands
    {
        Left = 'L',
        Right = 'R',
        Move = 'M',
    }

    public class RoverManager : IRoverController
    {
        public Rover rover { get; set; }
        public PlateauMatrix plateauMatrix { get; set; }

        public RoverManager(Rover rover, PlateauMatrix plateauMatrix)
        {
            this.rover = rover;
            this.plateauMatrix = plateauMatrix;
        }

        public void handleCommand(string command)
        {
            char[] charArr = command.ToCharArray();
            foreach (char ch in charArr)
            {
                switch (ch)
                {
                    case (char)Commands.Left:
                        rotateLeft();
                        break;
                    case (char)Commands.Right:
                        rotateRight();
                        break;
                    case (char)Commands.Move:
                        move();
                        break;
                }
            }
        }

        public Rover move()
        {
            try
            {
                switch (this.rover.direction)
                {
                    case (char)Directions.North:
                        if (this.plateauMatrix.UpperRight.yCoordinate > this.rover.position.yCoordinate)
                            this.rover.position.yCoordinate++;
                        else
                            throw new MovementIsNotAllowedException();
                        break;
                    case (char)Directions.East:
                        if (this.plateauMatrix.UpperRight.xCoordinate > this.rover.position.xCoordinate)
                            this.rover.position.xCoordinate++;
                        else
                            throw new MovementIsNotAllowedException();
                        break;
                    case (char)Directions.South:
                        if (this.plateauMatrix.LowerLeft.yCoordinate < this.rover.position.yCoordinate)
                            this.rover.position.yCoordinate--;
                        else
                            throw new MovementIsNotAllowedException();
                        break;
                    case (char)Directions.West:
                        if (this.plateauMatrix.LowerLeft.xCoordinate < this.rover.position.xCoordinate)
                            this.rover.position.xCoordinate--;
                        else
                            throw new MovementIsNotAllowedException();
                        break;
                }
            }
            catch (MovementIsNotAllowedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rover;
        }

        public Rover rotateLeft()
        {
            switch (this.rover.direction)
            {
                case (char)Directions.North:
                    this.rover.direction = 'W';
                    break;
                case (char)Directions.East:
                    this.rover.direction = 'N';
                    break;
                case (char)Directions.South:
                    this.rover.direction = 'E';
                    break;
                case (char)Directions.West:
                    this.rover.direction = 'S';
                    break;
            }
            return rover;
        }

        public Rover rotateRight()
        {
            switch (this.rover.direction)
            {
                case (char)Directions.North:
                    this.rover.direction = 'E';
                    break;
                case (char)Directions.East:
                    this.rover.direction = 'S';
                    break;
                case (char)Directions.South:
                    this.rover.direction = 'W';
                    break;
                case (char)Directions.West:
                    this.rover.direction = 'N';
                    break;
            }
            return rover;
        }
    }
}
