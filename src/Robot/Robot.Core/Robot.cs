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
            var newCoordinates = Execute(command.Command.ToCharArray(), command.Direction, command.X, command.Y);

            if (_grid.CollisionOccurred) return $"CRASHED {newCoordinates}";

            if (_grid.IsOutOfBounds) return "OUT OF BOUNDS";

            return newCoordinates == command.ExpectedOutput ? $"SUCCESS {newCoordinates}" : $"FAILURE {newCoordinates}";
        });

        return JsonSerializer.Serialize(result);
    }

    private string Execute(char[] commands, string direction, int x, int y)
    {
        var state = commands.Fold(new RobotState {Coordinates = new Coordinate(x, y), Direction = Direction.DefaultDirection(direction)},
            (state, command) => command switch
            {
                'R' => state with {Direction = state.Direction.RotateRight()},
                'L' => state with {Direction = state.Direction.RotateLeft()},
                'F' => state with {Coordinates = _grid.Move(state.Direction, state.Coordinates)},
                _ => state
            });

        return $"{state.Coordinates.X} {state.Coordinates.Y} {state.Direction.GetValue()}";
    }
}

internal record RobotState
{
    public Direction Direction { get; init; }
    public Coordinate Coordinates { get; init; }
}