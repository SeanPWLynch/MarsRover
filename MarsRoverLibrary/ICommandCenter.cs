using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public interface ICommandCenter
    {
        private static ICommandParser _commandParser { get; set; }
        private static IPlatue _platue { get; set; }
        private static IPlatue _rover { get; set; }
        bool ValidateAndExecuteCommand(string input);

        int GetRoverPositionX();
        int GetRoverPositionY();
        Direction GetRoverPositionDirection();
        int GetPlatueHeight();
        int GetPlatueWidth();

    }
}
