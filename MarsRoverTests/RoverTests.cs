using MarsRoverLibrary;
using NUnit.Framework;

namespace MarsRoverTests
{
    public class RoverTests
    {

        public Platue Platue { get; set; }

        [SetUp]
        public  void SetUp()
        {
            Platue = Platue.Create(5, 5);
        }

        [Test]
        public void RoverCreated()
        {

            IRover rover = Rover.Create();

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
            IRover rover = Rover.Create();

            rover.Move(Platue,new char[] { 'R' });

            Assert.IsTrue(rover.Position.Direction == Direction.East);
        }

        [TestCase("R", Direction.East)]
        [TestCase("RR", Direction.South)]
        [TestCase("RRR", Direction.West)]
        [TestCase("RRRR", Direction.North)]
        [TestCase("RRRRR", Direction.East)]
        public void RoverTurnRightMultiple(string input, Direction directionActual)
        {
            IRover rover = Rover.Create();

            rover.Move(Platue, input.ToCharArray());


            Assert.IsTrue(rover.Position.Direction == directionActual);
        }

        [Test]
        public void RoverTurnLeft()
        {
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'L' });

            Assert.IsTrue(rover.Position.Direction == Direction.West);
        }

        [TestCase("L", Direction.West)]
        [TestCase("LL", Direction.South)]
        [TestCase("LLL", Direction.East)]
        [TestCase("LLLL", Direction.North)]
        [TestCase("LLLLL", Direction.West)]
        public void RoverTurnLeftMultiple(string input, Direction directionActual)
        {
            IRover rover = new Rover();

            rover.Move(Platue, input.ToCharArray());


            Assert.IsTrue(rover.Position.Direction == directionActual);
        }

        [Test]
        public void RoverMoveForward()
        {
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'F' });

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
            IRover rover = Rover.Create();


            rover.Move(Platue, input.ToCharArray());
            

            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.North);
                Assert.IsTrue(rover.Position.Y == heightActual);
            });
        }

        [Test]
        public void RoverTurnAroundAndGoForward()
        {
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'R' });
            rover.Move(Platue, new char[] { 'R' });
            rover.Move(Platue, new char[] { 'F' });


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.South);
                Assert.IsTrue(rover.Position.X == 1);
            });
        }

        [Test]
        public void RoverTurnRightAndGoForward()
        {
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'R' });
            rover.Move(Platue, new char[] { 'F' });


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.East);
                Assert.IsTrue(rover.Position.Y == 1);
                Assert.IsTrue(rover.Position.X == 2);
            });
        }

        [Test]
        public void RoverForwardTwiceRightTwiceForwardTwice()
        {
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'F' });
            rover.Move(Platue, new char[] { 'F' });
            rover.Move(Platue, new char[] { 'R' });
            rover.Move(Platue, new char[] { 'R' });
            rover.Move(Platue, new char[] { 'F' });
            rover.Move(Platue, new char[] { 'F' });


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.South);
                Assert.IsTrue(rover.Position.Y == 1);
                Assert.IsTrue(rover.Position.X == 1);
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
            IRover rover = Rover.Create();


                rover.Move(Platue, input.ToCharArray());
            


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
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'L' });
            rover.Move(Platue, new char[] { 'F' });


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
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'R' });
            rover.Move(Platue, new char[] { 'F' });
            rover.Move(Platue, new char[] { 'L' });
            rover.Move(Platue, new char[] { 'F' });


            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.North);
                Assert.IsTrue(rover.Position.X == 2);
                Assert.IsTrue(rover.Position.Y == 2);
            });
        }

        [Test]
        public void RoverInvalidCommand()
        {
            IRover rover = Rover.Create();

            rover.Move(Platue, new char[] { 'X' });

            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.North);
                Assert.IsTrue(rover.Position.X == 1);
                Assert.IsTrue(rover.Position.Y == 1);
            });
        }


        [Test]
        public void RoverOperationalTest()
        {
            IRover rover = Rover.Create();

            string input = "FFRFLFLF";


           rover.Move(Platue, input.ToCharArray());
            

            Assert.Multiple(() =>
            {
                Assert.IsTrue(rover.Position.Direction == Direction.West);
                Assert.IsTrue(rover.Position.X == 1);
                Assert.IsTrue(rover.Position.Y == 4);
            });
        }



    }
}