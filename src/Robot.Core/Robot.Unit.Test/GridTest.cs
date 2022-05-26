using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core;

namespace Robots.Unit.Test;

[TestClass]
public class GridTest
{
    [TestMethod]
    public void Move_OutOfBounds_Should_Return_IsOutOfBounds()
    {
        var grid = new Grid(3, 4, Seq<Coordinate>.Empty);

        _ = grid.Move(Direction.DefaultDirection(Direction.WEST), new Coordinate(0, 0));

        Assert.IsTrue(grid.IsOutOfBounds);
    }

    [TestMethod]
    public void Move_WithObstacles_Should_Return_Collision()
    {
        var grid = new Grid(3, 4, new Seq<Coordinate>(new Coordinate[] { new(3, 1) }));

        _ = grid.Move(Direction.DefaultDirection(Direction.EAST), new Coordinate(2, 1));

        Assert.IsTrue(grid.CollisionOccurred);
    }

    [TestMethod]
    public void Should_Move_East()
    {
        var grid = new Grid(3, 4, Seq<Coordinate>.Empty);

        var coordinates = grid.Move(Direction.DefaultDirection(Direction.EAST), new Coordinate(1, 1));

        const int expected = 2;

        Assert.AreEqual(expected, coordinates.X);
    }

    [TestMethod]
    public void Should_Move_North()
    {
        var grid = new Grid(3, 4, Seq<Coordinate>.Empty);

        var coordinates = grid.Move(Direction.DefaultDirection(), new Coordinate(1, 1));

        const int expected = 2;

        Assert.AreEqual(expected, coordinates.Y);
    }

    [TestMethod]
    public void Should_Move_South()
    {
        var grid = new Grid(3, 4, Seq<Coordinate>.Empty);

        var coordinates = grid.Move(Direction.DefaultDirection(Direction.SOUTH), new Coordinate(1, 1));

        const int expected = 0;

        Assert.AreEqual(expected, coordinates.Y);
    }

    [TestMethod]
    public void Should_Move_West()
    {
        var grid = new Grid(3, 4, Seq<Coordinate>.Empty);

        var coordinates = grid.Move(Direction.DefaultDirection(Direction.WEST), new Coordinate(1, 1));

        const int expected = 0;

        Assert.AreEqual(expected, coordinates.X);
    }
}