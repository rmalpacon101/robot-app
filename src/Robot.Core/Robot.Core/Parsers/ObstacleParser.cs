using LanguageExt;

namespace Robots.Core.Parsers;

public class ObstacleParser : AbstractBaseParser<Seq<Coordinate>>
{
    public ObstacleParser(Arr<string> commands) : base(commands)
    {
    }

    public override Seq<Coordinate> Parse()
    {
        var commands = _commands.Filter(o => o.StartsWith("OBSTACLE"));

        return commands.Map(o =>
        {
            var values = o.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return values.Length >= 3 ? new Coordinate(int.Parse(values[1]), int.Parse(values[2])) : Coordinate.Default;

        }).ToSeq();
    }
}