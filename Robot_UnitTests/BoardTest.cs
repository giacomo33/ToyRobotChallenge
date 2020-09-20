using Robot.Boards;
using Robot.Interfaces;
using Robot.RobotEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Robot_UnitTests
{
    public class BoardTest
    {
        private IBoard _board;

        public BoardTest()
        {
            _board = new Board(5, 5);
        }

        [Fact]
        public void Board_Position_0_0_North_IsValid()
        {
            // Arrange
            var position = new Position(0, 0, Direction.North);

            // Act
            var isValidPosition = _board.IsValidPosition(position);

            // Assert
            Assert.True(isValidPosition);
        }

        [Fact]
        public void Board_Position_5_5_North_IsValid()
        {
            // Arrange
            var position = new Position(5, 5, Direction.North);

            // Act
            var isValidPosition = _board.IsValidPosition(position);

            // Assert
            Assert.True(isValidPosition);
        }

        [Fact]
        public void Board_Position_3_3_North_IsValid()
        {
            // Arrange
            var position = new Position(3, 3, Direction.North);

            // Act
            var isValidPosition = _board.IsValidPosition(position);

            // Assert
            Assert.True(isValidPosition);
        }

        [Fact]
        public void Board_Position_neg1_3_North_Invalid()
        {
            // Arrange
            var position = new Position(-1, 3, Direction.North);

            // Act
            var isValidPosition = _board.IsValidPosition(position);

            // Assert
            Assert.False(isValidPosition);
        }

        [Fact]
        public void Board_Position_neg1_neg3_North_Invalid()
        {
            // Arrange
            var position = new Position(-1, -3, Direction.North);

            // Act
            var isValidPosition = _board.IsValidPosition(position);

            // Assert
            Assert.False(isValidPosition);
        }
    }
}