namespace Robots.Core;

public class Grid
{
    private readonly int _columns;
    private readonly int _rows;

    public Grid(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
    }

    public bool IsOutOfBounds { get; private set; }

    public Coordinate GetCoordinate(Direction direction, Coordinate coordinates)
    {
        var y = coordinates.Y;
        var x = coordinates.X;

        var currentDirection = direction.GetValue();

        switch (currentDirection)
        {
            case Direction.NORTH:
                y += 1;
                break;
            case Direction.EAST:
                x += 1;
                break;
            case Direction.SOUTH:
                y -= 1;
                break;
            case Direction.WEST:
                x -= 1;
                break;
        }

        if (y > _rows || x > _columns || x <= -1 || y <= -1) IsOutOfBounds = true;

        return new Coordinate(x, y);
    }
}