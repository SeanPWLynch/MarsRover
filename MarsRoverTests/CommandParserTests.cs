using MarsRoverLibrary;
using NUnit.Framework;
using System.Linq;

namespace MarsRoverTests
{
    public class CommandParserTests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void ParsePlatuePass()
        {
            CommandParser commandParser = CommandParser.Create();
            
            var platueSize = commandParser.ParsePlatueSize("5x5");

            Platue platue = Platue.Create(platueSize[0], platueSize[1]);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(platue.Height, 5);
                Assert.AreEqual(platue.Width, 5);
            });

        }

        [Test]
        public void ParsePlatueReturnNull()
        {
            CommandParser commandParser = CommandParser.Create();

            var platueSize = commandParser.ParsePlatueSize("5T5");

            Assert.Multiple(() =>
            {
                Assert.IsNull(platueSize);
            });

        }


        [Test]
        public void ParsePlatueTooManyChar()
        {
            CommandParser commandParser = CommandParser.Create();

            var platueSize = commandParser.ParsePlatueSize("5X5X5");

            Assert.Multiple(() =>
            {
                Assert.IsNull(platueSize);
            });

        }

        [Test]
        public void ParseRoverCommand()
        {
            CommandParser commandParser = CommandParser.Create();

            var roverCommands = commandParser.ParseRoverCommand("FFL");



            Assert.Multiple(() =>
            {
                Assert.IsTrue(roverCommands.SequenceEqual(new char[] { 'F', 'F', 'L' }));
            });

        }

        [Test]
        public void ParseRoverCommandReturnNull()
        {
            CommandParser commandParser = CommandParser.Create();

            var roverCommands = commandParser.ParseRoverCommand("FFA");

            Assert.Multiple(() =>
            {
                Assert.IsNull(roverCommands);
            });

        }

    }
}