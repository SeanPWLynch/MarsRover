using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public class Rover : IRover
    {

        public Position Position { get; set; }

        public static Rover Create() { return new Rover(); }


        public Rover()
        {
            Position = Position.Create();
        }

        public void Move(IPlatue platue, char[] movements)
        {
            foreach (char movement in movements)
            {

                if (movement.Equals('F'))
                {
                    CheckEdgeAndMove(platue);
                }
                else if (movement.Equals('L'))
                {
                    if (this.Position.Direction == (Direction)1)
                    {
                        Position.Direction = (Direction)4;
                    }
                    else
                    {
                        Position.Direction -= 1;
                    }
                }
                else if (movement.Equals('R'))
                {
                    if (this.Position.Direction == (Direction)4)
                    {
                        Position.Direction = (Direction)1;
                    }
                    else
                    {
                        Position.Direction += 1;
                    }
                }
                else
                {
                    Console.WriteLine($"{movement} is not a valid input");
                }
            }
        }

        public void CheckEdgeAndMove(IPlatue platue)
        {
            if (this.Position.Direction == Direction.North)
            {
                if (!(Position.Y + 1 > platue.Height))
                {
                    Position.Y += 1;
                }
            }
            else if (this.Position.Direction == Direction.East)
            {
                if (!(Position.X + 1 > platue.Width))
                {
                    Position.X += 1;
                }

            }
            else if (this.Position.Direction == Direction.South)
            {
                if (!(Position.Y - 1 < 1))
                {
                    Position.Y -= 1;
                }

            }
            else if (this.Position.Direction == Direction.West)
            {
                if (!(Position.X - 1 < 1))
                {
                    Position.X -= 1;
                }
            }


        }



    }
}
