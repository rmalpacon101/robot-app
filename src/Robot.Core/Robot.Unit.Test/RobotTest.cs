using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core;

namespace Robots.Unit.Test;

[TestClass]
public class RobotTest
{
    private Robot _robot;

    [TestInitialize]
    public void Initialize()
    {
        _robot = new Robot();
    }

    [DataTestMethod]
    [DataRow("F", "1:0:S", 1, 1)]
    [DataRow("F", "1:1:S", 1, 2)]
    [DataRow("FF", "2:0:S", 2, 2)]
    public void Robot_Should_MoveDown(string command, string expected, int x, int y)
    {
        var result = _robot.Execute(command, Direction.SOUTH, x, y);

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("F", "0:1:W", 1, 1)]
    [DataRow("FF", "0:2:W", 2, 2)]
    public void Robot_Should_MoveLeft(string command, string expected, int x, int y)
    {
        var result = _robot.Execute(command, Direction.WEST, x, y);

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("RF", "1:0:E")]
    [DataRow("RFF", "2:0:E")]
    public void Robot_Should_MoveRight(string command, string expected)
    {
        var result = _robot.Execute(command);

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("F", "0:1:N")]
    [DataRow("FF", "0:2:N")]
    public void Robot_Should_MoveUp(string command, string position)
    {
        var result = _robot.Execute(command);

        Assert.AreEqual(position, result);
    }

    [DataTestMethod]
    [DataRow("L", "0:0:W")]
    [DataRow("LL", "0:0:S")]
    [DataRow("LLL", "0:0:E")]
    [DataRow("LLLL", "0:0:N")]
    [DataRow("LLLLL", "0:0:W")]
    public void Robot_Should_RotateLeft(string command, string position)
    {
        var result = _robot.Execute(command);

        Assert.AreEqual(position, result);
    }

    [DataTestMethod]
    [DataRow("R", "0:0:E")]
    [DataRow("RR", "0:0:S")]
    [DataRow("RRR", "0:0:W")]
    [DataRow("RRRR", "0:0:N")]
    [DataRow("RRRRR", "0:0:E")]
    public void Robot_Should_RotateRight(string command, string position)
    {
        var result = _robot.Execute(command);

        Assert.AreEqual(position, result);
    }

    [DataTestMethod]
    [DataRow("FFFFF", Direction.NORTH, "OUT OF BOUNDS")]
    [DataRow("FFFFF", Direction.EAST, "OUT OF BOUNDS")]
    [DataRow("FFFFF", Direction.WEST, "OUT OF BOUNDS")]
    [DataRow("FFFFF", Direction.SOUTH, "OUT OF BOUNDS")]
    public void Robot_MovesOutsideGridBoundary_Should_ReturnOutOfBounds(string command, string startingDirection, string expected)
    {
        var result = _robot.Execute(command, startingDirection);

        Assert.AreEqual(expected, result);
    }
}