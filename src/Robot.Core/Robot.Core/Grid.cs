namespace Robots.Core;

public class Grid
{
    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }

    public bool IsOutOfBounds { get; private set; }

    public int Rows { get; }

    public int Columns { get; }

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

        if (y > Rows || x > Columns || x <= -1 || y <= -1) IsOutOfBounds = true;

        return new Coordinate(x, y);
    }
}