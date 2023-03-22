using MarsRover;
using NUnit.Framework;

namespace MarsRoverTests
{
    public class RoverTests
    {

        public Platue Platue { get; set; }

        [SetUp]
        public  void SetUp()
        {
            Platue = new Platue(5, 5);
        }

        [Test]
        public void RoverCreated()
        {

           Rover rover = new Rover();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(rover.Position.X, 1);
                Assert.AreEqual(rover.Position.Y, 1);
                Assert.AreEqual(rover.Position.Direction, (Direction)1);
            });
        }


        [Test]
        public void RoverTurnRight()
        {
            Rover rover = new Rover();

            rover.Move(Platue,'R');

            Assert.IsTrue(rover.Position.Direction == Direction.East);
        }

        [TestCase("R", Direction.East)]
        [TestCase("RR", Direction.South)]
        [TestCase("RRR", Direction.West)]
        [TestCase("RRRR", Direction.North)]
        [TestCase("RRRRR", Direction.East)]
        public void RoverTurnRightMultiple(string input, Direction directionActual)
        {
            Rover rover = new Rover();

            foreach (char movement in input.ToCharArray())
            {
                rover.Move(Platue,movement);

            }


            Assert.IsTrue(rover.Position.Direction == directionActual);
        }

        [Test]
        public void RoverTurnLeft()
        {
            Rover rover = new Rover();

            rover.Move(Platue, 'L');

            Assert.IsTrue(rover.Position.Direction == Direction.West);
        }

        [TestCase("L", Direction.West)]
        [TestCase("LL", Direction.South)]
        [TestCase("LLL", Direction.East)]
        [TestCase("LLLL", Direction.North)]
        [TestCase("LLLLL", Direction.West)]
        public void RoverTurnLeftMultiple(string input, Direction directionActual)
        {
            Rover rover = new Rover();

            foreach (char movement in input.ToCharArray())
            {
                rover.Move(Platue, movement);

            }


            Assert.IsTrue(rover.Position.Direction == directionActual);
        }

        [Test]
        public void RoverMoveForward()
        {
            Rover rover = new Rover();

            rover.Move(Platue,'F');

            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.North);
                Assert.IsTrue(rover.Position.X == 1);
                Assert.IsTrue(rover.Position.Y == 2);
            });
        }

        [TestCase("F", 2)]
        [TestCase("FF", 3)]
        [TestCase("FFF", 4)]
        [TestCase("FFFF", 5)]
        [TestCase("FFFFF", 5)]
        [TestCase("FFFFFF", 5)]
        public void RoverMoveForwardMultiple(string input, int heightActual)
        {
            Rover rover = new Rover();

            foreach (char movement in input.ToCharArray())
            {
                rover.Move(Platue, movement);
            }

            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.North);
                Assert.IsTrue(rover.Position.Y == heightActual);
            });
        }

        [Test]
        public void RoverTurnAroundAndGoForward()
        {
            Rover rover = new Rover();

            rover.Move(Platue, 'R');
            rover.Move(Platue, 'R');
            rover.Move(Platue, 'F');
            

            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.South);
                Assert.IsTrue(rover.Position.X == 1);
            });
        }

        [Test]
        public void RoverTurnRightAndGoForward()
        {
            Rover rover = new Rover();

            rover.Move(Platue, 'R');
            rover.Move(Platue, 'F');


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.East);
                Assert.IsTrue(rover.Position.Y == 1);
                Assert.IsTrue(rover.Position.X == 2);
            });
        }

        [TestCase("R", 1,1, Direction.East)]
        [TestCase("RF", 1,2, Direction.East)]
        [TestCase("RFF", 1, 3, Direction.East)]
        [TestCase("RFFFF", 1, 5, Direction.East)]
        [TestCase("RFFFFF", 1, 5, Direction.East)]
        [TestCase("RFFFFFF", 1, 5, Direction.East)]
        public void RoverTurnRightAndGoForwardMultiple(string input, int heightActual, int widthActual, Direction directionActual)
        {
            Rover rover = new Rover();

            foreach (char movement in input.ToCharArray())
            {
                rover.Move(Platue, movement);
            }


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == directionActual);
                Assert.IsTrue(rover.Position.Y == heightActual);
                Assert.IsTrue(rover.Position.X == widthActual);
            });
        }

        [Test]
        public void RoverTurnLeftAndGoForward()
        {
            Rover rover = new Rover();

            rover.Move(Platue, 'L');
            rover.Move(Platue, 'F');


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.West);
                Assert.IsTrue(rover.Position.X == 1);
                Assert.IsTrue(rover.Position.Y == 1);
            });
        }

        [Test]
        public void RoverTurnRightAndGoForwardTurnLeftAndGoForward()
        {
            Rover rover = new Rover();

            rover.Move(Platue, 'R');
            rover.Move(Platue, 'F');
            rover.Move(Platue, 'L');
            rover.Move(Platue, 'F');


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.North);
                Assert.IsTrue(rover.Position.X == 2);
                Assert.IsTrue(rover.Position.Y == 2);
            });
        }

        [Test]
        public void RoverOperationalTest()
        {
            Rover rover = new Rover();

            string input = "FFRFLFLF";

            foreach (char movement in input.ToCharArray())
            {
                rover.Move(Platue, movement);
            }

            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.West);
                Assert.IsTrue(rover.Position.X == 1);
                Assert.IsTrue(rover.Position.Y == 4);
            });
        }



    }
}