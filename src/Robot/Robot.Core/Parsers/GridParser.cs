using LanguageExt;

namespace Robots.Core.Parsers;

public class GridParser : AbstractBaseParser<Grid>
{
    private readonly Seq<Coordinate> _obstacleCoordinates;

    public GridParser(Arr<string> commands, Seq<Coordinate> coordinates) : base(commands)
    {
        _obstacleCoordinates = coordinates;
    }

    public override Grid Parse() =>
        _commands
            .Find(o => o.StartsWith("GRID"))
            .Match(command => TryParseCommandValues(command, out var values) && values.Count >= 2 ? new Grid(values[1], values[0], _obstacleCoordinates) : Grid.Default, Grid.Default);
}