using System.Text.Json;
using LanguageExt;

namespace Robots.Core;

public class Robot
{
    private readonly Seq<RobotCommand> _commands;
    private readonly Grid _grid;

    public Robot(Seq<RobotCommand> commands, Grid grid)
    {
        _commands = commands;
        _grid = grid;
    }

    public string Execute()
    {
        var result = _commands.Map(command =>
        {
            var newCoordinates = Execute(command.Command, command.Direction, command.X, command.Y);

            if (_grid.CollisionOccurred) return $"CRASHED {newCoordinates}";

            if (_grid.IsOutOfBounds) return "OUT OF BOUNDS";

            return newCoordinates == command.ExpectedOutput ? $"SUCCESS {newCoordinates}" : $"FAILURE {newCoordinates}";
        });

        return JsonSerializer.Serialize(result);
    }

    private string Execute(string commands, string direction, int x, int y)
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
                    coordinates = _grid.Move(orientation, coordinates);
                    break;
            }

        return $"{coordinates.X} {coordinates.Y} {orientation.GetValue()}";
    }
}