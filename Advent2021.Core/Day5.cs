namespace Advent2021.Core;

using System.Text;

public abstract class Day5 : BasePuzzle
{
    protected Day5(int part, Input input) : base(5, part, input)
    {
    }

    /// <summary>
    ///     Parse input line into a pair of points
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    protected static (int x1, int y1, int x2, int y2) Parse(string line)
    {
        var result = line.Split("->")
            .Select(p => p.Trim())
            .Chunk(2)
            .Select(chunks => new
            {
                Start = chunks[0].Split(','),
                End = chunks[1].Split(',')
            })
            .Select(range => new
            {
                X1 = int.Parse(range.Start[0]),
                Y1 = int.Parse(range.Start[1]),
                X2 = int.Parse(range.End[0]),
                Y2 = int.Parse(range.End[1])
            })
            .First();

        return (result.X1, result.Y1, result.X2, result.Y2);
    }

    /// <summary>
    ///     Create a list of XY pairs forming a line
    /// </summary>
    protected static IEnumerable<(int x, int y)> MakeLine(int x1, int y1, int x2, int y2, bool acceptDiagonal)
    {
        // +1 because we need to include the end point for all lines
        var yDiff = Math.Abs(y2 - y1) + 1;
        var xDiff = Math.Abs(x2 - x1) + 1;

        if (xDiff == 1)
        {
            // Vertical line
            var xPoints = Enumerable.Repeat(x1, yDiff);
            var yPoints = y2 > y1 ? Enumerable.Range(y1, yDiff) : Enumerable.Range(y2, yDiff);
            return xPoints.Zip(yPoints, (x, y) => (x, y)).ToList();
        }

        if (yDiff == 1)
        {
            // Horizontal line
            var xPoints = x2 > x1 ? Enumerable.Range(x1, xDiff) : Enumerable.Range(x2, xDiff);
            var yPoints = Enumerable.Repeat(y1, xDiff);
            return xPoints.Zip(yPoints, (x, y) => (x, y)).ToList();
        }

        if (acceptDiagonal && xDiff == yDiff)
        {
            // Diagonal line
            var x = x1;
            var y = y1;
            var xInc = x2 > x1 ? 1 : -1;
            var yInc = y2 > y1 ? 1 : -1;
            var result = new List<(int, int)>(xDiff);
            for (var i = 0; i < xDiff; ++i)
            {
                result.Add((x, y));
                x += xInc;
                y += yInc;
            }

            return result;
        }

        return Enumerable.Empty<(int x, int y)>();
    }

    protected class Map
    {
        private readonly Dictionary<(int x, int y), int> _map = new(1024);

        public void MarkPoints(IEnumerable<(int x, int y)> points)
        {
            foreach (var point in points)
            {
                if (!_map.ContainsKey(point))
                {
                    _map[point] = 0;
                }

                ++_map[point];
            }
        }

        public int ReadOverlapping(int overlaps)
        {
            return _map.Count(p => p.Value >= overlaps);
        }

        public string Print(int rows = 10, int cols = 10)
        {
            var sb = new StringBuilder(1024);
            for (var row = 0; row < rows; ++row)
            {
                for (var col = 0; col < cols; ++col)
                {
                    var match = _map.FirstOrDefault(m => m.Key == (col, row));
                    var symbol = match.Value == 0 ? "." : match.Value.ToString();
                    sb.Append($"{symbol} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}

/// <summary>
///     Linear algebra
/// </summary>
public class Day5Part1 : Day5
{
    public Day5Part1(Input input) : base(1, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        var map = new Map();

        foreach (var line in _puzzleInput)
        {
            // x1,y1 -> x2,y2
            var (x1, y1, x2, y2) = Parse(line);

            // Expand point pair to line
            var points = MakeLine(x1, y1, x2, y2, false);

            // Plot line points on map
            map.MarkPoints(points);
        }

        var overlappingN = map.ReadOverlapping(2);

        return overlappingN.ToString();
    }
}

/// <summary>
///     Linear algebra
/// </summary>
public class Day5Part2 : Day5
{
    public Day5Part2(Input input) : base(2, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        var map = new Map();

        foreach (var line in _puzzleInput)
        {
            // x1,y1 -> x2,y2
            var (x1, y1, x2, y2) = Parse(line);

            // Expand point pair to line
            var points = MakeLine(x1, y1, x2, y2, true);

            // Plot line points on map
            map.MarkPoints(points);
        }

        var overlappingN = map.ReadOverlapping(2);

        return overlappingN.ToString();
    }
}