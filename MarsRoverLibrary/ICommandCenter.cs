using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public interface ICommandCenter
    {
        private static ICommandParser _commandParser;
        private static IPlatue _platue;
        private static IPlatue _rover;
        bool ValidateAndExecuteCommand(string input);

        int GetRoverPositionX();
        int GetRoverPositionY();
        Direction GetRoverPositionDirection();
        int GetPlatueHeight();
        int GetPlatueWidth();

    }
}
