namespace Advent2021.Test;

using Core;
using NUnit.Framework;

public class Day3Tests
{
    [Test]
    public void Day3Part1Test()
    {
        // Setup
        var data = new[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010",
        };
        const string expected = "198";
        var input = new Input(data);
        var solver = new Day3Part1(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
    
    [Test]
    public void Day3Part2Test()
    {
        // Setup
        var data = new[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010",
        };
        const string expected = "230";
        var input = new Input(data);
        var solver = new Day3Part2(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
}