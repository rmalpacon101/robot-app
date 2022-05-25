namespace Robots.Core;

public class Direction
{
    private readonly string _direction;
    private readonly string _left;
    private readonly string _right;

    public Direction(string direction, string right, string left)
    {
        _direction = direction;
        _right = right;
        _left = left;
    }

    public static Direction Default => Orientation["N"];

    private static Dictionary<string, Direction> Orientation => new()
    {
        ["N"] = new Direction("N", "E", "W"),
        ["E"] = new Direction("E", "S", "N"),
        ["S"] = new Direction("S", "W", "E"),
        ["W"] = new Direction("W", "N", "S")
    };

    private Direction GetDirection(string newDirection)
    {
        return Orientation[newDirection];
    }

    public string GetValue()
    {
        return _direction;
    }

    public Direction RotateLeft()
    {
        return GetDirection(_left);
    }

    public Direction RotateRight()
    {
        return GetDirection(_right);
    }
}