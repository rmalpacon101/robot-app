namespace Robots.Core;

public record Coordinate(int X, int Y)
{
    public static Coordinate Default => new(1, 1);
}