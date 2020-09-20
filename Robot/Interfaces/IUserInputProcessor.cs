using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface IUserInputProcessor
    {
        public List<string[]> ReadCommandsFromFile(string fileName);
    }
}