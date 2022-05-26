using System.Text.RegularExpressions;
using LanguageExt;

namespace Robots.Core.Parsers
{
    public abstract class AbstractBaseParser<T> : IParser<T>
    {
        protected readonly Arr<string> _commands;

        protected AbstractBaseParser(Arr<string> commands)
        {
            _commands = commands;
        }

        public abstract T Parse();

        protected bool TryParseCommandValues(string input, out Arr<int> res)
        {
            res = Arr<int>.Empty;

            Arr<string> values = new(Regex.Split(input, @"\D+").Where(o => !string.IsNullOrWhiteSpace(o)));

            res = values.Map(int.Parse);

            return !res.IsEmpty;
        }
    }
}
