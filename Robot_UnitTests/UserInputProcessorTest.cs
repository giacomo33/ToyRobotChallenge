using Robot.InputProcessors;
using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Robot_UnitTests
{
    public class UserInputProcessorTest
    {
        private IUserInputProcessor inputProcessor;

        public UserInputProcessorTest()
        {
            inputProcessor = new UserInputProcessor();
        }

        [Theory]
        [InlineData("Movement_test.txt")]
        [InlineData("Placement_test.txt")]
        [InlineData("PoorCommands.txt")]
        [InlineData("OffBoardMovementandPlacement_test.txt")]
        public void RobotSimulator_Run_Movement_test_File_ExecuteAsExpected(string fileName)
        {
            // Arrange

            // Act
            List<string[]> commandsInput = inputProcessor.ReadCommandsFromFile(fileName);

            // Assert
            Assert.True(commandsInput != null);
        }

        [Theory]
        [InlineData("DodgyData.txt")]
        [InlineData("Empty.txt")]
        public void RobotSimulator_Run_Empty_Or_DodgyData_File_(string fileName)
        {
            // Arrange

            // Act
            List<string[]> commandsInput = inputProcessor.ReadCommandsFromFile(fileName);

            // Assert
            Assert.True(commandsInput.Count == 0);
        }
    }
}