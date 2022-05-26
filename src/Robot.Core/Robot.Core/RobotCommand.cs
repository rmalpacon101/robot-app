namespace Robots.Core;

public record RobotCommand(int X, int Y, string Direction, string Command, string ExpectedOutput)
{
    public static RobotCommand Default => new(1, 1, Core.Direction.NORTH, string.Empty, string.Empty);
}