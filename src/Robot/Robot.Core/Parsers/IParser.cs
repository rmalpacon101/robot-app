namespace Robots.Core.Parsers;

public interface IParser<out T>
{
    T Parse();
}