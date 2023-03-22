using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public interface ICommandParser
    {
        int[] ParsePlatueSize(string input);
        char[] ParseRoverCommand(string input);
    }
}
