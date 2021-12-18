using NUnit.Framework;

namespace Advent2021.Test;

using System.Runtime.Versioning;
using Core;

public class Day1Tests
{
    [Test]
    [RequiresPreviewFeatures]
    public void Day1Part1Test()
    {
        // Setup
        var data = new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };
        const string expected = "7";
        var input = new Input(data);
        var solver = new Day1Part1(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
    
    [Test]
    [RequiresPreviewFeatures]
    public void Day1Part2Test()
    {
        // Setup
        var data = new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };
        const string expected = "5";
        var input = new Input(data);
        var solver = new Day1Part2(input);

        // Execute
        var solution = solver.Solve();

        // Assert
        Assert.AreEqual(expected, solution);
    }
}