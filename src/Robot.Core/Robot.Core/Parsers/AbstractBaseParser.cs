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
    }
}
