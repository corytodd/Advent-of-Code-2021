namespace Advent2021.Test;

using System.Runtime.Versioning;
using Core;
using NUnit.Framework;

public class Day7Tests
{
    [Test]
    [RequiresPreviewFeatures]
    public void Day7Part1Test()
    {
        // Setup
        var data = new[]
        {
            "16,1,2,0,4,2,7,1,2,14"
        };
        const string expected = "37";
        var input = new Input(data);
        var solver = new Day7Part1(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
    
    [Test]
    [RequiresPreviewFeatures]
    public void Day6Part2Test()
    {
        // Setup
        var data = new[]
        {
            "16,1,2,0,4,2,7,1,2,14"
        };
        const string expected = "168";
        var input = new Input(data);
        var solver = new Day7Part2(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
}