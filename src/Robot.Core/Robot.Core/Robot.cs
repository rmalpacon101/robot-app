namespace Robots.Core;

public class Robot
{
    private const int MAX_HEIGHTS_BOUNDS = 3;
    private const int MAX_WIDTH_BOUNDS = 4;

    public string Execute(string commands, string direction = Direction.NORTH, int x = 0, int y = 0)
    {
        var orientation = Direction.DefaultDirection(direction);
        var coordinates = new Coordinate(x, y);

        foreach (var command in commands.ToCharArray())
            switch (command)
            {
                case 'R':
                    orientation = orientation.RotateRight();
                    break;
                case 'L':
                    orientation = orientation.RotateLeft();
                    break;
                case 'F':
                    coordinates = Move(orientation, coordinates);
                    break;
            }

        if (coordinates.Y > MAX_HEIGHTS_BOUNDS || coordinates.X > MAX_WIDTH_BOUNDS) return "OUT OF BOUNDS";

        if (coordinates.X <= -1 || coordinates.Y <= -1) return "OUT OF BOUNDS";

        return $"{coordinates.X}:{coordinates.Y}:{orientation.GetValue()}";
    }

    private Coordinate Move(Direction direction, Coordinate currentCoordinate)
    {
        var y = currentCoordinate.Y;
        var x = currentCoordinate.X;

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

        return new Coordinate(x, y);
    }
}