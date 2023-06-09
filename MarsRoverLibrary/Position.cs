﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public class Position : IPosition
    {
        public int X { get; set; } = 1;
        public int Y { get; set; } = 1;
        public Direction Direction { get; set; } = Direction.North;

        public Position()
        {

        }

        public static Position Create()
        {
            return new Position();
        }

    }
}
