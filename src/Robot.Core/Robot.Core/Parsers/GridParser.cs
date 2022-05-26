using System.Text.RegularExpressions;
using LanguageExt;

namespace Robots.Core.Parsers;

public class GridParser : AbstractBaseParser<Grid>
{
    public GridParser(Arr<string> commands) : base(commands)
    {
    }

    public override Grid Parse()
    {
        Option<string> gridCommand = _commands.Find(o => o.StartsWith("GRID"));

        if (gridCommand.IsNone)
        {
            return new Grid(0, 0);
        }

        return gridCommand.Match(command =>
        {
            string[] values = Regex.Split(command, @"\D+").Where(o => !string.IsNullOrWhiteSpace(o)).ToArray();

            return new Grid(int.Parse(values[1]), int.Parse(values[0]));
        }, new Grid(0, 0));

    }
}