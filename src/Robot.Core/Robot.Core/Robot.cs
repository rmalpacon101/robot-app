namespace Robots.Core;

public class Robot
{
    private readonly Grid _grid;

    public Robot(Grid grid)
    {
        _grid = grid;
    }

    public string Execute(string commands, string direction = Direction.NORTH, int x = 0, int y = 0)
    {
        var orientation = Direction.DefaultDirection(direction);
        var coordinates = new Coordinate(x, y);

        foreach (var command in commands.ToCharArray())
        {
            switch (command)
            {
                case 'R':
                    orientation = orientation.RotateRight();
                    break;
                case 'L':
                    orientation = orientation.RotateLeft();
                    break;
                case 'F':
                    coordinates = _grid.GetCoordinate(orientation, coordinates);
                    break;
            }

            if (_grid.IsOutOfBounds) return "OUT OF BOUNDS";
        }

        return $"{coordinates.X}:{coordinates.Y}:{orientation.GetValue()}";
    }
}