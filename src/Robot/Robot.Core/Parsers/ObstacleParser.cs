using LanguageExt;

namespace Robots.Core.Parsers;

public class ObstacleParser : AbstractBaseParser<Seq<Coordinate>>
{
    public ObstacleParser(Arr<string> commands) : base(commands)
    {
    }

    public override Seq<Coordinate> Parse() =>
        _commands
            .Filter(o => o.StartsWith("OBSTACLE"))
            .Map(o => TryParseCommandValues(o, out var values) && values.Count >= 2 ? new Coordinate(values[0], values[1]) : Coordinate.Default).ToSeq();
}