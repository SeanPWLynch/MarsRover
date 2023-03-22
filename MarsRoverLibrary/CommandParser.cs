using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public class CommandParser : ICommandParser
    {
        Regex platuePattern = new Regex(@"[0-9][xX][0-9]");

        public static CommandParser Create()
        {
            return new CommandParser();
        }

        public int[] ParsePlatueSize(string input)
        {
            try
            {
                if(input.Trim().Length > 3)
                {
                    Console.WriteLine($"Input {input} is not a valid Platue Size, you have entered too many characters");
                    return null;

                }
                if (!(platuePattern.IsMatch(input.Trim())))
                {
                    Console.WriteLine($"Input {input} is not a valid Platue Size");
                    return null;
                }
                else
                {
                    var heightWidth = input.ToLower().Split("x");

                    return new int[] { int.Parse(heightWidth[0]), int.Parse(heightWidth[1]) };
                }
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public char[] ParseRoverCommand(string input)
        {
            char[] validMovements = { 'L', 'R', 'F' };
            try
            {
                {
                    if(input.Trim().ToUpper().Any(mov => !validMovements.Contains(mov)))
                    {
                        Console.WriteLine($"Invalid Movement In Command String");
                        return null;
                    }
                    return input.ToUpper().ToCharArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
}
