namespace Advent2021.Core;

using System.Numerics;

public abstract class Day6 : BasePuzzle
{
    protected Day6(int part, Input input) : base(6, part, input)
    {
    }

    protected BigInteger PopulationAfterDays(int days)
    {
        var initial = ReadSingleLineCommaIntegers();

        var fish = new BigInteger[9];
        foreach (var i in initial)
        {
            ++fish[i];
        }

        for (var day = 0; day < days; ++day)
        {
            var newFish = fish[0];
            for (var i = 0; i < fish.Length-1; ++i)
            {
                fish[i] = fish[i + 1];
            }

            fish[8] = newFish;
            fish[6] += newFish;
        }

        return fish
            .Aggregate<BigInteger, BigInteger>(0, (current, n) => current + n);
    }
}

/// <summary>
///     Exponential growth in linear time
/// </summary>
public class Day6Part1 : Day6
{
    public Day6Part1(Input input) : base(1, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        var pop = PopulationAfterDays(80);
        return pop.ToString();
    }
}

/// <summary>
///     Exponential growth in linear time
/// </summary>
public class Day6Part2 : Day6
{
    public Day6Part2(Input input) : base(2, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        var pop = PopulationAfterDays(256);
        return pop.ToString();
    }
}