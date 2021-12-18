namespace Advent2021.Core;

public abstract class Day3 : BasePuzzle
{
    protected Day3(int part, Input input) : base(3, part, input)
    {
    }

    /// <summary>
    ///     Read input data as binary integers
    ///     Data is treated interpreted as MSB
    /// </summary>
    protected IEnumerable<int> ReadBinaryIntegers()
    {
        foreach (var line in _puzzleInput)
        {
            var binary = new string(line);
            if (!BitConverter.IsLittleEndian)
            {
                binary = new string(line.Reverse().ToArray());
            }

            yield return Convert.ToInt32(binary, 2);
        }
    }

    /// <summary>
    ///     Reads bit count from input
    /// </summary>
    /// <returns>Count of bits in input data</returns>
    protected int GetBitCount()
    {
        var line = _puzzleInput.First();
        return line.Length;
    }
}

/// <summary>
///     Binary parsing
/// </summary>
public class Day3Part1 : Day3
{
    public Day3Part1(Input input) : base(1, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        var bits = GetBitCount();

        // key: bit index, value: bit set count
        var bitCount = new Dictionary<int, int>(bits);

        // Pre-populate bit counters to zero
        for (var bit = 0; bit < bits; ++bit)
        {
            bitCount[bit] = 0;
        }

        var elementCount = 0;
        foreach (var value in ReadBinaryIntegers())
        {
            ++elementCount;
            for (var bit = 0; bit < bits; ++bit)
            {
                var isSet = (value & (1 << bit)) != 0;

                if (isSet)
                {
                    bitCount[bit] += 1;
                }
            }
        }

        // gamma is most common bit for each position
        var gamma = 0;
        for (var bit = 0; bit < bits; ++bit)
        {
            var count = bitCount[bit];
            var value = count > (elementCount / 2) ? 1 : 0;

            gamma |= value << bit;
        }

        // epsilon is logical NOT of gamma w/ 2's complement
        var epsilon = ~gamma & (int)(Math.Pow(2, bits) - 1);

        var consumption = gamma * epsilon;
        return consumption.ToString();
    }
}