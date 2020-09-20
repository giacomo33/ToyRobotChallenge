using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Robot.RobotEntities;

namespace Robot.Boards
{
    public class Board : IBoard
    {
        private readonly long _width;
        private readonly long _length;

        public Board(long width, long length)
        {
            _width = width;
            _length = length;
        }

        /// <summary>Determines whether the position is within the boundaries of the board. The board's South-West corner is 0,0.</summary>
        /// <param name="position">The position.</param>
        /// <returns>
        ///   <c>true</c> if the position is within the board boundaries; otherwise, <c>false</c>.</returns>
        public bool IsValidPosition(Position position)
        {
            return position.X <= _width && position.X >= 0 && position.Y <= _length && position.Y >= 0;
        }
    }
}