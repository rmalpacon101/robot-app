using LanguageExt;

namespace Robots.Core;

public class Grid
{
    private readonly Seq<Coordinate> _obstacles;

    public Grid(int rows, int columns, Seq<Coordinate> obstacles)
    {
        Rows = rows;
        Columns = columns;
        _obstacles = obstacles;
    }

    public bool CollisionOccurred { get; private set; }

    public int Columns { get; }

    public bool IsOutOfBounds { get; private set; }

    public int Rows { get; }

    public Coordinate Move(Direction direction, Coordinate coordinates)
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

        var newCoordinates = new Coordinate(x, y);

        if (_obstacles.Exists(o => o == newCoordinates))
        {
            CollisionOccurred = true;

            return newCoordinates;
        }

        if (y > Rows || x > Columns || x <= -1 || y <= -1) IsOutOfBounds = true;

        return newCoordinates;
    }

    public static Grid Default => new(0, 0, Seq<Coordinate>.Empty);
}