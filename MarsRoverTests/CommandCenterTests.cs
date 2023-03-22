using MarsRoverLibrary;
using NUnit.Framework;
using System.Linq;
using System.Text;

namespace MarsRoverTests
{
    public class CommandCenterTests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void CreateCommandCenter()
        {
            string platueSize = "5x5";

            ICommandCenter commandCenter = CommandCenter.Create(platueSize);
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(commandCenter.GetPlatueHeight(),5);
                Assert.AreEqual(commandCenter.GetPlatueWidth(),5);
                Assert.AreEqual(commandCenter.GetRoverPositionX(),1);
                Assert.AreEqual(commandCenter.GetRoverPositionY(), 1);
                Assert.AreEqual(commandCenter.GetRoverPositionDirection(), Direction.North);
            });
        }

        [Test]
        public void TestMovement()
        {
            string platueSize = "5x5";
            
            ICommandCenter commandCenter = CommandCenter.Create(platueSize);

            string command = "FFRFLFLF";

            commandCenter.ValidateAndExecuteCommand(command);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(commandCenter.GetPlatueHeight(), 5);
                Assert.AreEqual(commandCenter.GetPlatueWidth(), 5);
                Assert.AreEqual(commandCenter.GetRoverPositionX(), 1);
                Assert.AreEqual(commandCenter.GetRoverPositionY(), 4);
                Assert.AreEqual(commandCenter.GetRoverPositionDirection(), Direction.West);
            });
        }

    }
}