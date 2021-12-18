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

/// <summary>
///     Binary parsing
/// </summary>
public class Day3Part2 : Day3
{
    public Day3Part2(Input input) : base(2, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        var bits = GetBitCount();

        var oxygenRating = FilterBinary(bits, true);
        var co2ScrubberRating = FilterBinary(bits, false);

        var lifeSupportRating = oxygenRating * co2ScrubberRating;

        return lifeSupportRating.ToString();
    }

    /// <summary>
    ///     Filter binary data by bit position until one remains
    /// </summary>
    /// <param name="bits">Count of bits in data</param>
    /// <param name="mostCommon">True to keep most common bit</param>
    /// <returns>Final filtered down value</returns>
    private int FilterBinary(int bits, bool mostCommon)
    {

        // Oxygen generator rate: filter by bit, most common bit, 1 if tied
        var hashedInput = new HashSet<int>(ReadBinaryIntegers());
        for (var bit = bits - 1; bit >= 0; --bit)
        {
            var bitStateCount = new Dictionary<bool, int> { { true, 0 }, { false, 0 } };

            // Stop when we have a single value
            if (hashedInput.Count == 1)
            {
                break;
            }

            // Count bit state in the remaining set
            foreach (var value in hashedInput)
            {
                var isSet = (value & (1 << bit)) != 0;
                ++bitStateCount[isSet];
            }
            
            // Decide which to keep.
            var keepState = mostCommon switch
            {
                // Keep most common bits. If tied, select 1.
                true => bitStateCount[true] >= bitStateCount[false] ? 1 : 0,
                
                // Keep lead common bit, If tied select 0.
                false => bitStateCount[false] <= bitStateCount[true] ? 0 : 1
            };

            hashedInput.RemoveWhere(v => (v & (1 << bit)) != keepState << bit);
        }


        return hashedInput.First();
    }
}