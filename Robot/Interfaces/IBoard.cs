using System;
using System.Collections.Generic;
using System.Text;
using Robot.Boards;
using Robot.RobotEntities;

namespace Robot.Interfaces
{
    public interface IBoard
    {
        bool IsValidPosition(Position position);
    }
}