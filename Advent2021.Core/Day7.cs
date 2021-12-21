namespace Advent2021.Core;

using System.Runtime.Versioning;

public abstract class Day7 : BasePuzzle
{
    protected Day7(int part, Input input) : base(7, part, input)
    {
    }
}

public class Day7Part1 : Day7
{
    public Day7Part1(Input input) : base(1, input)
    {
    }

    /// <inheritdoc />
    [RequiresPreviewFeatures]
    public override string Solve()
    {
        var horizontalPositions = ReadSingleLineCommaIntegers().ToList();
        var median = horizontalPositions.Median<int, int>();
        var cost = horizontalPositions.Aggregate(0, (cost, current) => Math.Abs(current - median) + cost);

        return cost.ToString();
    }
}

public class Day7Part2 : Day7
{
    public Day7Part2(Input input) : base(2, input)
    {
    }

    /// <inheritdoc />
    [RequiresPreviewFeatures]
    public override string Solve()
    {
        var horizontalPositions = ReadSingleLineCommaIntegers().ToList();

        // Average is imprecise so check the floor and ceiling for this value
        var average = horizontalPositions.Average();
        
        var costLow = (from h in horizontalPositions
                select Math.Abs(h - Math.Floor(average))
                into diff
                select Math.Ceiling(diff / 2 * (diff + 1))
                into prod
                select prod)
            .Sum();
        
        var costHigh = (from h in horizontalPositions
                select Math.Abs(h - Math.Ceiling(average))
                into diff
                select Math.Ceiling(diff / 2 * (diff + 1))
                into prod
                select prod)
            .Sum();

        return ((int)Math.Round(Math.Min(costLow, costHigh))).ToString();
    }
}