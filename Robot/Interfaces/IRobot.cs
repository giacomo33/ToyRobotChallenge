using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using Robot.RobotEntities;

namespace Robot.Interfaces
{
    public interface IRobot
    {
        Position CurrentPosition { get; set; }

        void Place(Position position);

        void Move();

        void TurnLeft();

        void TurnRight();

        void Report();

        void Validate(string expectedOutput);
    }
}