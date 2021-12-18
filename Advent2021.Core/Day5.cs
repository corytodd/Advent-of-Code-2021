namespace Advent2021.Core;

using System.Collections;

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
    protected static IEnumerable<(int x, int y)> MakeLine(int x1, int y1, int x2, int y2)
    {
        var line = new List<(int x, int y)>(1024);
        
        // Keeps things simple and make lines incrementing
        (x1, x2) = (Math.Min(x1, x2), Math.Max(x1, x2));
        (y1, y2) = (Math.Min(y1, y2), Math.Max(y1, y2));

        var (x, y) = (x1, y1);
        var done = false;
        while(!done)
        {
            line.Add((x, y));
            if (x1 == x2)
            {
                ++y;
            }
            else
            {
                ++x;
            }

            // If X values are the same, we're 
            done = x1 == x2 ? y == y2 + 1 : x == x2 + 1;
        }
        
        return line;
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
            
            // consider only horizontal or vertical lines
            if (x1 != x2 && y1 != y2)
            {
                continue;
            }
            
            var points = MakeLine(x1, y1, x2, y2);

            map.MarkPoints(points);
        }
        
        var overlappingN = map.ReadOverlapping(2);

        return overlappingN.ToString();
    }
}