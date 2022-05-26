using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core.Parsers;

namespace Robots.Unit.Test.Parsers;

[TestClass]
public class CommandParserTest
{
    [TestMethod]
    public void Parse_Should_ReturnOneRobotCommand()
    {
        CommandParser parser = new(new Arr<string>(new[] { "1 1 E", "RFR", "1 0 W" }));

        var result = parser.Parse();

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count > 0);
    }
}