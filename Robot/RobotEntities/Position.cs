using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.RobotEntities
{
    public class Position
    {
        private long _x;
        private long _y;
        private Direction _facing;

        public long X { get => _x; set => _x = value; }
        public long Y { get => _y; set => _y = value; }
        public Direction Facing { get => _facing; set => _facing = value; }

        public Position(long x, long y, Direction facing)
        {
            _x = x;
            _y = y;
            _facing = facing;
        }

        public override string ToString()
        {
            return $"{_x},{_y},{_facing}";
        }

        public override bool Equals(object obj)
        {
            var positionObj = (Position)obj;
            return this.X == positionObj.X && this.Y == positionObj.Y && this.Facing == positionObj.Facing;
        }
    }
}