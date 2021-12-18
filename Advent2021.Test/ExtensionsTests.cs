namespace Advent2021.Test;

using System.Linq;
using System.Runtime.Versioning;
using Core;
using NUnit.Framework;

public class ExtensionsTests
{
    /// <summary>
    ///     Increasing diff test
    /// </summary>
    [Test]
    [RequiresPreviewFeatures]
    public void DiffIncreasing()
    {
        // Setup
        var data = Enumerable.Range(0, 10).ToList();
        var expected = Enumerable.Repeat(1, 9);

        // Execute
        var actual = data.Diff<int, int>();

        // Assert
        Assert.AreEqual(expected, actual);
    }
    
    /// <summary>
    ///     Decreasing diff test
    /// </summary>
    [Test]
    [RequiresPreviewFeatures]
    public void DiffDecreasing()
    {
        // Setup
        var data = Enumerable.Range(0, 10).Reverse().ToList();
        var expected = Enumerable.Repeat(-1, 9);

        // Execute
        var actual = data.Diff<int, int>();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}