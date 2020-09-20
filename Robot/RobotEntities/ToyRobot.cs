using Robot.Helpers;
using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.RobotEntities
{
    public class ToyRobot : IRobot
    {
        public Position CurrentPosition { get; set; } = null;
        private readonly IBoard _board;

        public ToyRobot(IBoard board)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
        }

        private Position GetNextPosition()
        {
            Position nextPosition = new Position(CurrentPosition.X, CurrentPosition.Y, CurrentPosition.Facing);

            switch (nextPosition.Facing)
            {
                case Direction.North:
                    nextPosition.Y += 1;
                    break;

                case Direction.South:
                    nextPosition.Y -= 1;
                    break;

                case Direction.East:
                    nextPosition.X += 1;
                    break;

                case Direction.West:
                    nextPosition.X -= 1;
                    break;
            }

            return nextPosition;
        }

        public void Place(Position position)
        {
            if (!_board.IsValidPosition(position))
            {
                Console.WriteLine($"PLACE failed. Invalid position {position}.");
                return;
            }
            if (CurrentPosition == null)
            {
                CurrentPosition = new Position(position.X, position.Y, position.Facing);
            }
            else
            {
                CurrentPosition.X = position.X;
                CurrentPosition.Y = position.Y;
                CurrentPosition.Facing = position.Facing;
            }
        }

        public void Move()
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine($"Robot has not been set. Discard MOVE.");
                return;
            }

            var nextPosition = GetNextPosition();
            if (_board.IsValidPosition(nextPosition))
            {
                CurrentPosition.X = nextPosition.X;
                CurrentPosition.Y = nextPosition.Y;
                CurrentPosition.Facing = nextPosition.Facing;
            }
            else
            {
                Console.WriteLine($"MOVE failed. Invalid position {nextPosition}.");
                return;
            }
        }

        public void TurnLeft()
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine($"Robot has not been set. Discard LEFT.");
                return;
            }
            switch (CurrentPosition.Facing)
            {
                case Direction.North:
                    CurrentPosition.Facing = Direction.West;
                    break;

                case Direction.South:
                    CurrentPosition.Facing = Direction.East;
                    break;

                case Direction.East:
                    CurrentPosition.Facing = Direction.North;
                    break;

                case Direction.West:
                    CurrentPosition.Facing = Direction.South;
                    break;
            }
        }

        public void TurnRight()
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine($"Robot has not been set. Discard RIGHT.");
                return;
            }
            switch (CurrentPosition.Facing)
            {
                case Direction.North:
                    CurrentPosition.Facing = Direction.East;
                    break;

                case Direction.South:
                    CurrentPosition.Facing = Direction.West;
                    break;

                case Direction.East:
                    CurrentPosition.Facing = Direction.South;
                    break;

                case Direction.West:
                    CurrentPosition.Facing = Direction.North;
                    break;
            }
        }

        public void Report()
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine($"Robot has not been set. Discard REPORT.");
                return;
            }
            Console.WriteLine($"Output: {CurrentPosition.X},{CurrentPosition.Y},{DirectionDescription()}");
        }

        public void Validate(string expectedOutput)
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine($"Robot has not been set. Discard VALIDATE.");
                return;
            }
            Console.WriteLine($"Expected output: {expectedOutput}");
        }

        private string DirectionDescription()
        {
            return CurrentPosition != null ? CurrentPosition.Facing.ToString().ToUpper() : string.Empty;
        }
    }
}