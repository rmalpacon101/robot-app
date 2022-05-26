using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core.Parsers;

namespace Robots.Unit.Test.Parsers;

[TestClass]
public class ObstacleParserTest
{
    [TestMethod]
    public void Parse_Should_ReturnOneCoordinate()
    {
        ObstacleParser parser = new(new Arr<string>(new[] {"OBSTACLE 1 2", "OBSTACLE 1 3", "OBSTACLE 2 4"}));

        var result = parser.Parse();

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count > 0);
        Assert.IsTrue(result[0].X > 0);
        Assert.IsTrue(result[0].Y > 0);
    }
}