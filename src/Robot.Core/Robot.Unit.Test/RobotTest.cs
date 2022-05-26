using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core;

namespace Robots.Unit.Test;

[TestClass]
public class RobotTest
{
    [DataTestMethod]
    [DataRow(1, 1, "E", "RFR", "1 0 W")]
    public void Execute_Command_Should_Return_SUCCESS(int x, int y, string direction, string command, string expectedOutput)
    {
        Seq<RobotCommand> commands = new(new RobotCommand[] { new(x, y, direction, command, expectedOutput) });

        Grid grid = new(3, 4, Seq<Coordinate>.Empty);

        Robot robotExecuter = new(commands, grid);

        var expected = "[\"SUCCESS 1 0 W\"]";

        var result = robotExecuter.Execute();

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(1, 1, "E", "RFRF", "1 1 E")]
    public void Execute_ExpectedOutputNotMatching_Should_ReturnFailure(int x, int y, string direction, string command, string expectedOutput)
    {
        Seq<RobotCommand> commands = new(new RobotCommand[] { new(x, y, direction, command, expectedOutput) });

        Grid grid = new(3, 4, Seq<Coordinate>.Empty);

        Robot robot = new(commands, grid);

        var expected = "[\"FAILURE 0 0 W\"]";

        var result = robot.Execute();

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(1, 1, "E", "FF", "1 0 W")]
    public void Execute_Moves_Collision_Should_ReturnCrashed(int x, int y, string direction, string command, string expectedOutput)
    {
        Seq<RobotCommand> commands = new(new RobotCommand[] { new(x, y, direction, command, expectedOutput) });

        Grid grid = new(3, 4, new Seq<Coordinate>(new[] { new Coordinate(3, 1) }));

        Robot robot = new(commands, grid);

        var expected = "[\"CRASHED 3 1 E\"]";

        var result = robot.Execute();

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(1, 1, "E", "RFF", "1 1 E")]
    public void Execute_MovesOutsideGridBoundary_Should_ReturnOutOfBounds(int x, int y, string direction, string command, string expectedOutput)
    {
        Seq<RobotCommand> commands = new(new RobotCommand[] { new(x, y, direction, command, expectedOutput) });

        Grid grid = new(3, 4, Seq<Coordinate>.Empty);

        Robot robot = new(commands, grid);

        var expected = "[\"OUT OF BOUNDS\"]";

        var result = robot.Execute();

        Assert.AreEqual(expected, result);
    }
}