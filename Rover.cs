using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {

        public Position Position { get; set; } = new Position();

        public Rover()
        {

        }

        public void Move(Platue platue, char movement)
        {
            if (movement.Equals('F'))
            {
                CheckEdge(platue);
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

        public void CheckEdge(Platue platue)
        {
            if (this.Position.Direction == Direction.North)
            {
                if (!(Position.Y + 1 > platue.Height))
                {
                    Position.Y += 1;
                }
                else
                {
                    ImSorryDave();
                }
            }
            else if (this.Position.Direction == Direction.East)
            {
                if (!(Position.X + 1 > platue.Width))
                {
                    Position.X += 1;
                }
                else
                {
                    ImSorryDave();
                }

            }
            else if (this.Position.Direction == Direction.South)
            {
                if (!(Position.Y - 1 < 1))
                {
                    Position.Y -= 1;
                }
                else
                {
                    ImSorryDave();
                }

            }
            else if (this.Position.Direction == Direction.West)
            {
                if (!(Position.X - 1 < 1))
                {
                    Position.X -= 1;
                }
                else
                {
                    ImSorryDave();
                }
            }


        }

        public void ImSorryDave()
        {
            Console.Write($"I'm sorry, Dave. I'm afraid I can't do that. I would fall from the {Position.Direction} Face");

        }



    }
}
