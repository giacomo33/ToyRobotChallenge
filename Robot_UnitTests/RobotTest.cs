using Robot.Boards;
using Robot.Interfaces;
using Robot.RobotEntities;
using System;
using Xunit;

namespace Robot_UnitTests
{
    public class RobotTest
    {
        private IBoard _board;
        private IRobot robot;

        public RobotTest()
        {
            _board = new Board(5, 5);
            robot = new ToyRobot(_board);
        }

        [Fact]
        public void Robot_Place_3_1_NORTH()
        {
            // Arrange
            var position = new Position(3, 1, Direction.North);

            // Act
            robot.Place(position);
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(position));
        }

        [Fact]
        public void Robot_SinglePlace_OffBoard_neg1_1_NORTH_CurrentPositionNull()
        {
            // Arrange
            var position = new Position(-1, 1, Direction.North);

            // Act
            robot.Place(position);
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition == null);
        }

        [Fact]
        public void Robot_MultiPlace_OffBoard_neg1_1_NORTH_NegPlaceDiscarded()
        {
            // Arrange
            var position1 = new Position(2, 2, Direction.North);
            var position2 = new Position(3, 1, Direction.North);
            var position3 = new Position(-1, 1, Direction.North);

            // Act
            robot.Place(position1);
            robot.Place(position2);
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(position2));
        }

        [Fact]
        public void Robot_Place_3_1_NORTH_Move()
        {
            // Arrange
            var initialPosition = new Position(3, 1, Direction.North);
            var finalPosition = new Position(3, 2, Direction.North);

            // Act
            robot.Place(initialPosition);
            robot.Move();
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void Robot_Place_3_3_NORTH_Left()
        {
            // Arrange
            var initialPosition = new Position(3, 3, Direction.North);
            var finalPosition = new Position(3, 3, Direction.West);

            // Act
            robot.Place(initialPosition);
            robot.TurnLeft();
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void Robot_Place_3_3_NORTH_Right()
        {
            // Arrange
            var initialPosition = new Position(3, 3, Direction.North);
            var finalPosition = new Position(3, 3, Direction.East);

            // Act
            robot.Place(initialPosition);
            robot.TurnRight();
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void Robot_Place_5_1_EAST_Move_MustDiscardMove()
        {
            // Arrange
            var initialPosition = new Position(5, 1, Direction.East);
            var finalPosition = new Position(5, 1, Direction.East);

            // Act
            robot.Place(initialPosition);
            robot.Move();
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void Robot_Place_1_5_NORTH_Move_MustDiscardMove()
        {
            // Arrange
            var initialPosition = new Position(1, 5, Direction.North);
            var finalPosition = new Position(1, 5, Direction.North);

            // Act
            robot.Place(initialPosition);
            robot.Move();
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void Robot_Place_0_1_WEST_Move_MustDiscardMove()
        {
            // Arrange
            var initialPosition = new Position(0, 1, Direction.West);
            var finalPosition = new Position(0, 1, Direction.West);

            // Act
            robot.Place(initialPosition);
            robot.Move();
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void Robot_Place_1_0_SOUTH_Move_MustDiscardMove()
        {
            // Arrange
            var initialPosition = new Position(1, 0, Direction.South);
            var finalPosition = new Position(1, 0, Direction.South);

            // Act
            robot.Place(initialPosition);
            robot.Move();
            var currentPosition = robot.CurrentPosition;

            // Assert
            Assert.True(currentPosition.Equals(finalPosition));
        }

        [Fact]
        public void RobotHasNotBeenPlaced_Move_MustDiscardCommand()
        {
            // Act
            robot.Move();

            // Assert
            Assert.True(robot.CurrentPosition == null);
        }

        [Fact]
        public void RobotHasNotBeenPlaced_Left_MustDiscardCommand()
        {
            // Act
            robot.TurnLeft();

            // Assert
            Assert.True(robot.CurrentPosition == null);
        }

        [Fact]
        public void RobotHasNotBeenPlaced_Right_MustDiscardCommand()
        {
            // Arrange

            // Act
            robot.TurnRight();

            // Assert
            Assert.True(robot.CurrentPosition == null);
        }

        [Fact]
        public void RobotHasNotBeenPlaced_Report_MustDiscardCommand()
        {
            // Arrange

            // Act
            robot.Report();

            // Assert
            Assert.True(robot.CurrentPosition == null);
        }

        [Fact]
        public void RobotHasNotBeenPlaced_Validate_MustDiscardCommand()
        {
            // Arrange
            var expectedOutput = "0,0,NORTH";
            // Act
            robot.Validate(expectedOutput);

            // Assert
            Assert.True(robot.CurrentPosition == null);
        }
    }
}