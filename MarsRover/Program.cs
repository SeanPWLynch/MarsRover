using MarsRoverLibrary;
using System.Numerics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarsRover;
class Program
{
    static void Main(string[] args) 
    {
        var host = CreateHostBuilder(args).Build();


        Console.WriteLine("Welcome to NASA, the space agency that's so hip, it's practically orbiting itself! \n" +
            "We've got rockets that go faster than a caffeinated cheetah, and scientists who are smarter than the average supercomputer (with better senses of humor too, if we do say so ourselves).  \n" +
            "So strap on your space helmet, take a deep breath, and get ready for the ride of your life - because at NASA, the galaxy is our playground and the stars are our swing set! \n");

        Console.WriteLine("Hey you! Yes, you! Are you ready to take on the challenge of controlling a Mars Rover? \n" +
    "It's as easy as pie, or at least as easy as it is for a supercomputer with a brain the size of a small planet. So why not give it a go? \n" +
    "Go ahead, take those controls and show the galaxy what you're made of! And if all else fails, don't panic - just remember, the answer is always 42.  \n" +
    "Happy exploring! \n");

        Console.WriteLine("Ah, the controls for the Mars Rover.As easy as pie for those of us with brains the size of small planets.Here goes: \n" +
            "L\" is for \"Left\", as in turn the robot to the left. \n" +
            "R\" is for \"Right\", as in turn the robot to the right. \n" +
            "And \"F\" is for \"Forward\", as in move the robot in the direction it's facing. \n" +
            "It's all quite simple really, unless of course you're a Vogon with a penchant for poetry, in which case we recommend getting a Babelfish to translate this for you. Good luck out there, space explorer! \n");



        Console.WriteLine("Please enter your commands now \n");

        Console.ReadKey();
        Console.WriteLine("\n");


        Console.WriteLine("Now hold on just a moment there, space cadet. \n" +
            "We can't just hand over the controls of a real-life Mars Rover to just anyone! We've got a reputation to uphold, you know. \n" +
            "But fear not, we've got the next best thing - a simulator! That's right, you'll be able to experience all the thrills and spills of controlling a Mars Rover, without the risk of accidentally sending it careening off a cliff. \n" +
            "So don't take it personally, we just want to make sure you're fully prepared before we hand over the keys to the real thing. Now, let's fire up that simulator and get you ready for blast off! \n");

        Console.WriteLine("Alrighty then, space explorer. Before we can launch you into the exciting world of Mars Rover simulation, we need to set up the game board, so to speak. \n" +
            "And that means choosing the size of the grid you'll be operating on. So go ahead and type in the size you want - for example, 5x5 or 10x10. Just remember, the bigger the grid, the bigger the challenge (and the bigger the fun, of course!). So choose wisely, and get ready for a virtual adventure like no other! \n");

        Console.WriteLine("Please enter your grid size now \n");

        var commandCenter = host.Services.GetService<CommandCenter>();

        do
        {
          commandCenter = CommandCenter.Create(Console.ReadLine());

        } while (commandCenter is null);


        Console.WriteLine("Attention, space explorer! The simulator command center is up and running, and the Mars Rover is ready for your command. So without further ado, let's get this show on the road, enter your directional commands now and start exploring!\n");

        Console.WriteLine("Please enter your commands now \n");


        bool validCommandsRecieved = false;
        do
        {
            validCommandsRecieved = commandCenter.ValidateAndExecuteCommand(Console.ReadLine());

        } while (validCommandsRecieved is false);
        

        Console.WriteLine($"Excellent work, space explorer! You've successfully navigated the Mars Rover through the treacherous terrain of the simulation grid, and have reached your destination. \n" +
            $"And just in case you were wondering, your current coordinates are {commandCenter.GetRoverPositionX()},{commandCenter.GetRoverPositionY()} and your direction is {commandCenter.GetRoverPositionDirection()}.  \n" +
            $"You're a natural at this! But don't rest on your laurels just yet - there's still plenty of exploring to do out there in the great beyond. So keep on truckin', and let's see where your intrepid spirit takes you next!\n");


        Console.WriteLine("To exit the simulator type EXIT, or keep entering commands to drive the rover\n");

        bool simulatorOn = true;
        do
        {
            string input = Console.ReadLine();

            if (input.Equals("EXIT"))
            {
                simulatorOn = false;
            }
            else
            {
                commandCenter.ValidateAndExecuteCommand(input);
                Console.WriteLine($"Current Position Is {commandCenter.GetRoverPositionX()}, {commandCenter.GetRoverPositionY()},{commandCenter.GetRoverPositionDirection()}");
            }
            

        } while (simulatorOn is true);

    }


    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<Program>();
                services.AddTransient<ICommandCenter, CommandCenter>();
            });
    }

}

