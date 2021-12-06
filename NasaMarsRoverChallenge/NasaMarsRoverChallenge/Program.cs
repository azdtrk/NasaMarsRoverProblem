using System;
using System.Text.RegularExpressions;
using NasaMarsRoverChallenge.Concrete;
using NasaMarsRoverChallenge.Entities;

namespace NasaMarsRoverChallenge
{
    class Program
    {
        public static void Main(string[] args)
        {

            #region Rover and Plateau related variables

            Position roverOnePosition = new Position(0, 0);
            string firstRoverCommand = string.Empty;
            char roverOneDirection = '\0';
            Position roverSecondPosition = new Position(0, 0);
            string secondRoverCommand = string.Empty;
            char roverSecondDirection = '\0';
            PlateauMatrix plateauMatrix = new PlateauMatrix(new Position(0, 0));

            #endregion

            #region User Input operations

            int inputLineCounter = 0;
            while (inputLineCounter != 5)
            {
                //var inputLine = Console.ReadLine().Trim(); 
                switch (inputLineCounter)
                {
                    case 0:
                        Console.WriteLine("Please provide plateau area matrix: (for ex: 5 5)");
                        var inputLine = Console.ReadLine().Trim();
                        inputLine = RemoveSpecialCharactersAndLetters(inputLine).Substring(0, 2);
                        plateauMatrix = new PlateauMatrix(new Position(int.Parse(inputLine.Substring(0, 1)), int.Parse(inputLine.Substring(1, 1))));
                        break;

                    case 1:
                        Console.WriteLine("Please provide first rover's loation: (for ex: 1 2 N)");
                        inputLine = Console.ReadLine().Trim();
                        inputLine = RemoveSpecialCharacters(inputLine);
                        while (inputLine.Length != 3)
                        {
                            Console.WriteLine("You have to provide 3 digit location!!");
                            inputLine = Console.ReadLine().Trim();
                            inputLine = RemoveSpecialCharacters(inputLine);
                        }
                        roverOnePosition = new Position(int.Parse(inputLine.Substring(0, 1)), int.Parse(inputLine.Substring(1, 1)));
                        roverOneDirection = Convert.ToChar(inputLine.Substring(2, 1).ToUpper());
                        break;

                    case 2:
                        Console.WriteLine("Please provide first rover's command: (for ex: LMLMLMLMM)");
                        inputLine = Console.ReadLine().Trim();
                        inputLine = RemoveSpecialCharactersAndNumbers(inputLine);
                        firstRoverCommand = inputLine.ToUpper();
                        break;

                    case 3:
                        Console.WriteLine("Please provide second rover's loation: (for ex: 3 3 E)");
                        inputLine = Console.ReadLine().Trim();
                        inputLine = RemoveSpecialCharacters(inputLine);
                        while (inputLine.Length != 3)
                        {
                            Console.WriteLine("You have to provide 3 digit location!!");
                            inputLine = Console.ReadLine().Trim();
                            inputLine = RemoveSpecialCharacters(inputLine);
                        }
                        roverSecondPosition = new Position(int.Parse(inputLine.Substring(0, 1)), int.Parse(inputLine.Substring(1, 1)));
                        roverSecondDirection = Convert.ToChar(inputLine.Substring(2, 1).ToUpper());
                        inputLine = RemoveSpecialCharacters(inputLine);
                        break;

                    case 4:
                        Console.WriteLine("Please provide first rover's command: (for ex: MMRMMRMRRM)");
                        inputLine = Console.ReadLine().Trim();
                        inputLine = RemoveSpecialCharactersAndNumbers(inputLine);
                        secondRoverCommand = inputLine.ToUpper();
                        break;
                }
                inputLineCounter++;
            }

            #endregion

            Console.WriteLine("Output: ");

            Rover roverOne = new Rover(roverOnePosition, roverOneDirection);
            RoverManager roverManager = new RoverManager(roverOne, plateauMatrix);
            roverManager.handleCommand(firstRoverCommand);
            displayRoverPosition(roverOne);

            Rover roverSecond = new Rover(roverSecondPosition, roverSecondDirection);
            /*
                Same menager can be used to menage other rover
                since there is no difference between the rovers in regards of their movements
            */
            roverManager = new RoverManager(roverSecond, plateauMatrix);
            roverManager.handleCommand(secondRoverCommand);
            displayRoverPosition(roverSecond);

            Console.ReadLine();
        }

        public static void displayRoverPosition(Rover rover)
        {
            Console.WriteLine(rover.position.xCoordinate + " " + rover.position.yCoordinate + " " + rover.direction);
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        public static string RemoveSpecialCharactersAndLetters(string str)
        {
            return Regex.Replace(str, "[^0-9_.]+", "", RegexOptions.Compiled);
        }

        public static string RemoveSpecialCharactersAndNumbers(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z_.]+", "", RegexOptions.Compiled);
        }
    }
}
