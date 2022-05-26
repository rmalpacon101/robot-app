namespace Robots.Core;

public record RobotCommand(int X, int Y, string Direction, string Command, string ExpectedOutput);