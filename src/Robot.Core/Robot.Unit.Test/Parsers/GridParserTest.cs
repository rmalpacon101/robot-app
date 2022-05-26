using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core.Parsers;

namespace Robots.Unit.Test.Parsers;

[TestClass]
public class GridParserTest
{
    [TestMethod]
    public void Grid_Should_ReturnOneGrid()
    {
        var gridParser = new GridParser(new Arr<string>(new[] { "GRID 4x3" }));

        var result = gridParser.Parse();

        var expectedCol = 4;
        var expectedRows = 3;

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCol, result.Columns);
        Assert.AreEqual(expectedRows, result.Rows);
    }

    [TestMethod]
    public void Grid_Should_ReturnOneGrid_WithColumnsRowsSetTo0()
    {
        var gridParser = new GridParser(new Arr<string>(new[] { "" }));

        var result = gridParser.Parse();

        var expectedCol = 0;
        var expectedRows = 0;

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCol, result.Columns);
        Assert.AreEqual(expectedRows, result.Rows);
    }
}