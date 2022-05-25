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

    private static IReadOnlyDictionary<string, Direction> Orientation => new Dictionary<string, Direction>
    {
        [NORTH] = new(NORTH, EAST, WEST),
        [EAST] = new(EAST, SOUTH, NORTH),
        [SOUTH] = new(SOUTH, WEST, EAST),
        [WEST] = new(WEST, NORTH, SOUTH)
    };
    
    public static Direction DefaultDirection(string direction = NORTH) => Orientation[direction];

    private Direction GetDirection(string newDirection) => Orientation[newDirection];

    public string GetValue() => _direction;

    public Direction RotateLeft() => GetDirection(_left);

    public Direction RotateRight() => GetDirection(_right);
}