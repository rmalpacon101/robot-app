using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core;
using Robots.Core.Parsers;

namespace Robots.Unit.Test.Parsers;

[TestClass]
public class GridParserTest
{
    [TestMethod]
    public void Grid_Should_ReturnOneGrid()
    {
        var commands = new Arr<string>(new[] {"GRID 4x3"});
        var gridParser = new GridParser(commands, Seq<Coordinate>.Empty);

        var result = gridParser.Parse();

        const int expectedCol = 4;
        const int expectedRows = 3;

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCol, result.Columns);
        Assert.AreEqual(expectedRows, result.Rows);
    }

    [TestMethod]
    public void Grid_Should_ReturnOneGrid_WithColumnsRowsSetTo0()
    {
        var commands = new Arr<string>(new[] {""});
        var gridParser = new GridParser(commands, Seq<Coordinate>.Empty);

        var result = gridParser.Parse();

        const int expectedCol = 0;
        const int expectedRows = 0;

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCol, result.Columns);
        Assert.AreEqual(expectedRows, result.Rows);
    }
}