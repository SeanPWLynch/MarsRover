using MarsRover;
using NUnit.Framework;

namespace MarsRoverTests
{
    public class PlatueTests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void PlatueCreated()
        {

            int height = 5;
            int width = 5;

            Platue platue = new Platue(height,width);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(platue.Height, height);
                Assert.AreEqual(platue.Width, width);
            });

        }

        [TestCase("5x5",5,5)]
        [TestCase("2x5",2,5)]
        [TestCase("7X4",7,4)]
        public void PlatueCreatedFromInput(string input, int heightActual, int widthActual)
        {
            var heightWidth = input.ToLower().Split("x");

            int height = int.Parse(heightWidth[0]);
            int width = int.Parse(heightWidth[1]);

            Platue platue = new Platue(height, width);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(platue.Height, heightActual);
                Assert.AreEqual(platue.Width, widthActual);
            });

        }

    }
}