using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position
    {
        public int X { get; set; } = 1;
        public int Y { get; set; } = 1;
        public Direction Direction { get; set; } = Direction.North;

        public Position()
        {

        }

    }
}
