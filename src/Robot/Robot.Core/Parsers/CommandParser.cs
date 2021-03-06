using LanguageExt;

namespace Robots.Core.Parsers;

public class CommandParser : AbstractBaseParser<Seq<RobotCommand>>
{
    public CommandParser(Arr<string> commands) : base(commands)
    {
    }

    private Map<int, Seq<string>> GetCommands()
    {
        var commands = _commands.Filter(o => !o.StartsWith("OBSTACLE") && !o.StartsWith("GRID"));

        var map = new Map<int, Seq<string>>();

        var groupIndex = 0;

        foreach (var command in commands)
        {
            if (string.IsNullOrWhiteSpace(command)) groupIndex++;

            map = map.AddOrUpdate(groupIndex, list => list.Add(command), () => string.IsNullOrWhiteSpace(command) ? Seq<string>.Empty : new Seq<string>(new[] { command }));
        }

        return map;
    }

    public override Seq<RobotCommand> Parse()
    {
        return GetCommands()
            .ToSeq()
            .Filter(o => o.Value.Any())
            .Map(o =>
            {
                var list = o.Value;

                return TryParseCommandValues(list[0], out var coords) ? new RobotCommand(coords[0], coords[1], $"{list[0][^1]}", list[1], list[2]) : RobotCommand.Default;
            });
    }
}