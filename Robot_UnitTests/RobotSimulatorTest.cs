using Robot;
using Robot.Boards;
using Robot.InputProcessors;
using Robot.Interfaces;
using Robot.RobotEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Robot_UnitTests
{
    public class RobotSimulatorTest
    {
        private RobotSimulator simulator;
        private IRobot robot;

        public RobotSimulatorTest()
        {
            IBoard board = new Board(5, 5);
            robot = new ToyRobot(board);
            IUserInputProcessor inputProcessor = new UserInputProcessor();

            simulator = new RobotSimulator(robot, inputProcessor);
        }

        [Fact]
        public void RobotSimulator_Run_Movement_test_File_ExecuteAsExpected()
        {
            // Arrange
            string fileName = "Movement_test.txt";

            // Act
            simulator.Run(fileName);
            var finalPosition = new Position(4, 4, Direction.East);
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void RobotSimulator_Run_Placement_test_File_ExecuteAsExpected()
        {
            // Arrange
            string fileName = "Placement_test.txt";

            // Act
            simulator.Run(fileName);
            var finalPosition = new Position(1, 4, Direction.West);
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void RobotSimulator_Run_PoorCommands_File_ExecuteAsExpected()
        {
            // Arrange
            string fileName = "PoorCommands.txt";

            // Act
            simulator.Run(fileName);
            var finalPosition = new Position(3, 3, Direction.North);
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void RobotSimulator_Run_OffBoardMoveAndPlace_File_ExecuteAsExpected()
        {
            // Arrange
            string fileName = "OffBoardMovementandPlacement_test.txt";

            // Act
            simulator.Run(fileName);
            var finalPosition = new Position(0, 3, Direction.West);
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Theory]
        [InlineData("DodgyData.txt")]
        [InlineData("Empty.txt")]
        public void RobotSimulator_Run_Empty_Or_DodgyData_File_(string fileName)
        {
            // Arrange

            // Act
            simulator.Run(fileName);

            // Assert
            Assert.True(robot.CurrentPosition == null);
        }
    }
}