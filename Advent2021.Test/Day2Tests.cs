namespace Advent2021.Test;

using Core;
using NUnit.Framework;

public class Day2Tests
{
    [Test]
    public void Day2Part1Test()
    {
        // Setup
        var data = new[]
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2",
        };
        const string expected = "150";
        var input = new Input(data);
        var solver = new Day2Part1(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
}