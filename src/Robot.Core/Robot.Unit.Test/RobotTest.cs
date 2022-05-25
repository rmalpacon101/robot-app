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
    [DataRow("L", "0:0:W")]
    [DataRow("LL", "0:0:S")]
    [DataRow("LLL", "0:0:E")]
    [DataRow("LLLL", "0:0:N")]
    [DataRow("LLLLL", "0:0:W")]
    public void Rotate_Should_RotateLeft(string command, string position)
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
    public void Rotate_Should_RotateRight(string command, string position)
    {
        var result = _robot.Execute(command);

        Assert.AreEqual(position, result);
    }
}