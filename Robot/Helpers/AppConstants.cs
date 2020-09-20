using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Helpers
{
    public static class AppConstants
    {
        /// <summary>Robot command contants.</summary>
        public const string place = "PLACE";

        public const string move = "MOVE";
        public const string left = "LEFT";
        public const string right = "RIGHT";
        public const string report = "REPORT";
        public const string validate = "VALIDATE";

        /// <summary>Robot direction constants.</summary>
        public const string north = "NORTH";

        public const string south = "SOUTH";
        public const string east = "EAST";
        public const string west = "WEST";

        /// <summary>Test file included.</summary>
        public const string goodMovement = "Movement_test.txt";

        public const string goodPlacement = "Placement_test.txt";
        public const string offBoard = "OffBoardMovementandPlacement_test.txt";

        public const string poorCommands = "PoorCommands.txt";
    }
}