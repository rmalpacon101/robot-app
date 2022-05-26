using System.Text.RegularExpressions;
using LanguageExt;

namespace Robots.Core.Parsers;

public class GridParser : AbstractBaseParser<Grid>
{
    private readonly Seq<Coordinate> _obstacleCoordinates;

    public GridParser(Arr<string> commands, Seq<Coordinate> coordinates) : base(commands)
    {
        _obstacleCoordinates = coordinates;
    }

    public override Grid Parse()
    {
        Option<string> gridCommand = _commands.Find(o => o.StartsWith("GRID"));
        
        return gridCommand.Match(command =>
        {
            string[] values = Regex.Split(command, @"\D+").Where(o => !string.IsNullOrWhiteSpace(o)).ToArray();

            return values.Length >= 2
                ? new Grid(int.Parse(values[1]), int.Parse(values[0]), _obstacleCoordinates)
                : Grid.Default;

        }, Grid.Default);

    }
}