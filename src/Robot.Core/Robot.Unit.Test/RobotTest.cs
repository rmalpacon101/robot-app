using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots.Core;

namespace Robots.Unit.Test
{
    [TestClass]
    public class RobotTest
    {
        [DataTestMethod]
        [DataRow("R", "0:0:E")]
        [DataRow("RR", "0:0:S")]
        [DataRow("RRR", "0:0:W")]
        [DataRow("RRRR", "0:0:N")]
        [DataRow("RRRRR", "0:0:E")]
        public void Rotate_Should_RotateRight(string command, string position)
        {
            Robot robot = new();

            string result = robot.Execute(command);

            Assert.AreEqual(position, result);
        }

        [DataTestMethod]
        [DataRow("L", "0:0:W")]
        [DataRow("LL", "0:0:S")]
        [DataRow("LLL", "0:0:E")]
        [DataRow("LLLL", "0:0:N")]
        [DataRow("LLLLL", "0:0:W")]
        public void Rotate_Should_RotateLeft(string command, string position)
        {
            Robot robot = new();

            string result = robot.Execute(command);

            Assert.AreEqual(position, result);
        }
    }
}
