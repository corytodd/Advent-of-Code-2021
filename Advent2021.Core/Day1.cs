namespace Advent2021.Core;

using System;
using System.Runtime.Versioning;

/// <summary>
///     Day 1 puzzles
/// </summary>
public abstract class Day1 : BasePuzzle
{
    protected Day1(Input input, int part) : base(1, part, input)
    {
    }

}

/// <summary>
///     Day 1 part 1
/// </summary>
public class Day1Part1 : Day1
{
    public Day1Part1(Input input) : base(input, 1)
    {
    }
    
    /// <inheritdoc />
    [RequiresPreviewFeatures]
    public override string Solve()
    {
        var input = ReadIntegers().ToArray();
        var diff = input.Diff<int, int>();
        var increasingCount = diff.Count(d => d > 0);
        return increasingCount.ToString();
    }
}


/// <summary>
///     Day 1 part 2
/// </summary>
public class Day1Part2 : Day1
{
    public Day1Part2(Input input) : base(input, 2)
    {
    }
    
    /// <inheritdoc />
    [RequiresPreviewFeatures]
    public override string Solve()
    {
        const int windowSize = 3;
        var input = ReadIntegers().ToArray();
        var segment = new ArraySegment<int>(input);
        var increasingCount = 0;

        int? prev = null;
        
        // Stop when we don't have enough data to make a complete window
        for(var i=0; input.Length - i >= windowSize; ++i)
        {
            // Manually create sliding windows using ArraySegment
            var window = segment.Slice(i, windowSize);
            var next = window.Sum();

            if (prev is not null)
            {
                if (next - prev > 0)
                {
                    ++increasingCount;
                }
            }

            prev = next;
        }
        
        return increasingCount.ToString();
    }
}