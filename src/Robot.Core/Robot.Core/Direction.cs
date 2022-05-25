namespace Robots.Core;

public class Direction
{
    public const string NORTH = "N";
    public const string SOUTH = "S";
    public const string EAST = "E";
    public const string WEST = "W";

    private readonly string _direction;
    private readonly string _left;
    private readonly string _right;

    public Direction(string direction, string right, string left)
    {
        _direction = direction;
        _right = right;
        _left = left;
    }

    private static Dictionary<string, Direction> Orientation => new()
    {
        [NORTH] = new Direction(NORTH, EAST, WEST),
        [EAST] = new Direction(EAST, SOUTH, NORTH),
        [SOUTH] = new Direction(SOUTH, WEST, EAST),
        [WEST] = new Direction(WEST, NORTH, SOUTH)
    };

    public static Direction DefaultDirection(string direction = NORTH) => Orientation[direction];

    private Direction GetDirection(string newDirection) => Orientation[newDirection];

    public string GetValue() => _direction;

    public Direction RotateLeft() => GetDirection(_left);

    public Direction RotateRight() => GetDirection(_right);
}