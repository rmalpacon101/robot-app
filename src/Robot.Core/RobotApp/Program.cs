// See https://aka.ms/new-console-template for more information

using Robots.Core;
using Robots.Core.Parsers;

//var file = @"C:\Users\malpa\Downloads\robot-dev-test\robot-dev-test\RobotApp\Sample3.txt";




async Task Init()
{
    if (args.Length == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please provide a sample file path");

        return;
    }

    if (!File.Exists(args[0]))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine("Command file not found");

        return;
    }

    var commands = await File.ReadAllLinesAsync(args[0]);

    var robotCommands = new CommandParser(commands).Parse();
    var obstacles = new ObstacleParser(commands).Parse();
    var grid = new GridParser(commands, obstacles).Parse();

    var robot = new Robot(robotCommands, grid);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(robot.Execute());
}

await Init();

Console.ResetColor();