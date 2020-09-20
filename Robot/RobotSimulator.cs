using Robot.Helpers;
using Robot.Interfaces;
using Robot.RobotEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class RobotSimulator
    {
        private readonly IRobot _robot;
        private readonly IUserInputProcessor _userInput;

        /// <summary>Initializes a new instance of the RobotSimulator class.</summary>
        /// <param name="board">The board.</param>
        /// <param name="robot">The robot.</param>
        /// <param name="userInput">The user input.</param>
        public RobotSimulator(IRobot robot, IUserInputProcessor userInput)
        {
            _robot = robot ?? throw new ArgumentNullException(nameof(robot));
            _userInput = userInput ?? throw new ArgumentNullException(nameof(userInput));
        }

        /// <summary>Runs simulator with data from the specified input file.</summary>
        /// <param name="inputFile">The input file name.</param>
        /// <exception cref="ArgumentNullException">Input text file must be provided.</exception>
        public void Run(string inputFile)
        {
            if (string.IsNullOrEmpty(inputFile))
                throw new ArgumentNullException("Input text file must be provided.");
            try
            {
                List<string[]> commandList = new List<string[]>();
                commandList = _userInput.ReadCommandsFromFile(inputFile);

                if (commandList == null || commandList.Count == 0)
                {
                    Console.WriteLine($"Unable to retrieve commands from the text file {inputFile}.");
                    return;
                }

                Console.WriteLine("\n================================");
                foreach (var command in commandList)
                {
                    ExecuteCommand(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>Executes the robot command.</summary>
        /// <param name="command">String array that represents a command.
        /// The array will have only one member for commands MOVE, LEFT, RIGHT, REPORT
        /// and 2 members for PLACE command: command[0]="PLACE" and command[1] in format "X,Y,FACING"</param>
        /// <exception cref="ArgumentNullException">Command cannot be null.</exception>
        /// <exception cref="Exception">Invalid command.</exception>
        private void ExecuteCommand(string[] command)
        {
            if (command == null)
                throw new ArgumentNullException("Command cannot be null.");

            try
            {
                switch (command[0])
                {
                    case (AppConstants.place):
                        if (command.Length != 2)
                        {
                            Console.WriteLine("PLACE command failed. Invalid command.");
                            return;
                        }

                        Position position = ValidatePositionInput(command[1]);
                        if (position == null)
                        {
                            Console.WriteLine("PLACE command failed. Position cannot be null.");
                            return;
                        }

                        _robot.Place(position);
                        Console.WriteLine(AppConstants.place + " " + command[1]);
                        break;

                    case (AppConstants.move):
                        Console.WriteLine($"{AppConstants.move}");
                        _robot.Move();
                        break;

                    case (AppConstants.left):
                        Console.WriteLine($"{AppConstants.left}");
                        _robot.TurnLeft();
                        break;

                    case (AppConstants.right):
                        Console.WriteLine($"{AppConstants.right}");
                        _robot.TurnRight();
                        break;

                    case (AppConstants.report):
                        Console.WriteLine(AppConstants.report);
                        _robot.Report();

                        break;

                    case (AppConstants.validate):
                        _robot.Validate(command[1]);
                        Console.WriteLine("\n================================");
                        break;

                    default:
                        throw new Exception($"Invalid command {command[0]}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>Validate input for position and returns position object.</summary>
        /// <param name="positionString">String to convert</param>
        /// <returns>Position of the robot.</returns>
        /// <exception cref="ArgumentNullException">Position cannot be null.</exception>
        /// <exception cref="ArgumentException">Invalid position.
        /// or
        /// Unable to parse X.
        /// or
        /// Unable to parse Y.</exception>
        private Position ValidatePositionInput(string positionString)
        {
            if (string.IsNullOrEmpty(positionString))
                throw new ArgumentNullException("Position cannot be null.");

            try
            {
                var positionItems = positionString.Split(",");

                if (positionItems.Length != 3)
                    throw new ArgumentException("Invalid input for position.");

                if (!long.TryParse(positionItems[0], out long x))
                    throw new ArgumentException("Invalid input for X.");

                if (!long.TryParse(positionItems[1], out long y))
                    throw new ArgumentException("Invalid input for Y.");

                string directionInput = positionItems[2].ToUpper();

                Direction direction = (directionInput) switch
                {
                    (AppConstants.north) => Direction.North,
                    (AppConstants.south) => Direction.South,
                    (AppConstants.east) => Direction.East,
                    (AppConstants.west) => Direction.West,
                    _ => throw new ArgumentException("Invalid input for direction."),
                };

                Position position = new Position(x, y, direction);

                return position;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
    }
}