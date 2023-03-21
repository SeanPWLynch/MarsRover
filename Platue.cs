using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Platue
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Platue(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
