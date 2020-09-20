using Robot.Helpers;
using Robot.Interfaces;
using Robot.RobotEntities;
using Robot.Boards;
using Robot.InputProcessors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Robot
{
    internal class Program
    {
        private static string[] validAnswers = { "1", "2", "3", "4" };

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Toy Robot Simulation.");
            Console.WriteLine("Please select test data file:");
            Console.WriteLine($"1 - {AppConstants.goodMovement}");
            Console.WriteLine($"2 - {AppConstants.goodPlacement}");
            Console.WriteLine($"3 - {AppConstants.offBoard}");
            Console.WriteLine($"4 - {AppConstants.poorCommands}");

            Console.WriteLine("Enter S to stop");

            try
            {
                RunSimulation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + ex.Message);
            }
        }

        private static void RunSimulation()
        {
            IBoard board = new Board(5, 5);
            IRobot robot = new ToyRobot(board);
            IUserInputProcessor inputProcessor = new UserInputProcessor();

            RobotSimulator simulator = new RobotSimulator(robot, inputProcessor);

            var fileName = string.Empty;
            var answer = Console.ReadLine().ToLower();

            while (answer != "s")
            {
                if (answer == "1")
                    fileName = AppConstants.goodMovement;
                else if (answer == "2")
                    fileName = AppConstants.goodPlacement;
                else if (answer == "3")
                    fileName = AppConstants.offBoard;
                else if (answer == "4")
                    fileName = AppConstants.poorCommands;
                else
                {
                    Console.WriteLine("Wrong entry. Try again or stop.");
                }

                robot.CurrentPosition = null;

                if (IsValidAnswer(answer))
                    simulator.Run(fileName);

                answer = Console.ReadLine().ToLower();
            }
        }

        private static bool IsValidAnswer(string answer)
        {
            return validAnswers.Contains(answer);
        }
    }
}