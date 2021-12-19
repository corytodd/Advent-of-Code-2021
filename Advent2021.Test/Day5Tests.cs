namespace Advent2021.Test;

using Core;
using NUnit.Framework;

public class Day5Tests
{
    [Test]
    public void Day5Part1Test()
    {
        // Setup
        var data = new[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };
        const string expected = "5";
        var input = new Input(data);
        var solver = new Day5Part1(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
    
    [Test]
    public void Day5Part2Test()
    {
        // Setup
        var data = new[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };
        const string expected = "12";
        var input = new Input(data);
        var solver = new Day5Part2(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
}