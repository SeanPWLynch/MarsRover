using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public class CommandCenter : ICommandCenter
    {

        private ICommandParser _commandParser { get; set; }

        private IPlatue _platue { get; set; }

        private IRover _rover { get; set; }

        public CommandCenter(CommandParser commandParser, Platue platue, Rover rover)
        {
            _commandParser = commandParser;
            _platue = platue;
            _rover = rover;
        }

        public static CommandCenter Create(string platueSize)
        {
            var commandParser = CommandParser.Create();
            int[] heightWidth = commandParser.ParsePlatueSize(platueSize);
            if (heightWidth != null)
            {
                return new CommandCenter(CommandParser.Create(), Platue.Create(heightWidth[0], heightWidth[1]), Rover.Create());

            }
            else
            {
                return null;
            }
        }

        public int GetPlatueHeight()
        {
            return _platue.Height;
        }

        public int GetPlatueWidth()
        {
            return _platue.Width;
        }

        public Direction GetRoverPositionDirection()
        {
            return _rover.Position.Direction;
        }

        public int GetRoverPositionX()
        {
            return _rover.Position.X;
        }

        public int GetRoverPositionY()
        {
            return (_rover.Position.Y);
        }

        public bool ValidateAndExecuteCommand(string input)
        {
            char[] command = _commandParser.ParseRoverCommand(input);
            if(command is not null)
            {
                _rover.Move(_platue, command);
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
