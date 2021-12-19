namespace Advent2021.Test;

using Core;
using NUnit.Framework;

public class Day6Tests
{
    [Test]
    public void Day6Part1Test()
    {
        // Setup
        var data = new[]
        {
            "3,4,3,1,2"
        };
        const string expected = "5934";
        var input = new Input(data);
        var solver = new Day6Part1(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
    
    [Test]
    public void Day6Part2Test()
    {
        // Setup
        var data = new[]
        {
            "3,4,3,1,2"
        };
        const string expected = "26984457539";
        var input = new Input(data);
        var solver = new Day6Part2(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
}