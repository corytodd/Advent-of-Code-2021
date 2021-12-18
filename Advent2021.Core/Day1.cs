namespace Advent2021.Core;

using System.Runtime.Versioning;

public class Day1 : BasePuzzle
{
    public Day1(Input input) : base(1, input)
    {
    }

    /// <inheritdoc />
    [RequiresPreviewFeatures]
    public override string Solve()
    {
        var input = ReadIntegers().ToArray();
        var diff = input.Diff<int, int>();
        var increaseCount = diff.Count(d => d > 0);
        return increaseCount.ToString();
    }
}