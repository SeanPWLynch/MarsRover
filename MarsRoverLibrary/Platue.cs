using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public class Platue : IPlatue
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Platue(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public static Platue Create(int height, int width)
        {
            return new Platue(height, width);
        }
    }
}
