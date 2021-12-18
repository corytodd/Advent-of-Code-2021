namespace Advent2021.Core;

/// <summary>
///     Day 2 puzzles
/// </summary>
public abstract class Day2 : BasePuzzle
{
    protected Day2(int day, int part, Input input) : base(day, part, input)
    {
    }

    /// <summary>
    ///     Interpret source file as navigation data
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException">File contains invalid data</exception>
    protected IEnumerable<Navigation> ReadNavigations()
    {
        foreach (var line in _puzzleInput)
        {
            var parts = line.Split(" ");
            yield return new Navigation
            {
                Direction = parts[0] switch
                {
                    "forward" => Direction.Forward,
                    "down" => Direction.Down,
                    "up" => Direction.Up,
                    _ => throw new ArgumentOutOfRangeException(line)
                },
                Distance = int.Parse(parts[1])
            };
        }
    }
}

/// <summary>
///     Day two 2D navigation
/// </summary>
public class Day2Part1 : Day2 
{
    public Day2Part1(Input input) : base(2, 1, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        // Starts at 0,0
        var position = new Position();

        foreach (var nav in ReadNavigations())
        {
            switch (nav.Direction)
            {
                case Direction.Up:
                    position.Depth -= nav.Distance;
                    break;
                case Direction.Down:
                    position.Depth += nav.Distance;
                    break;
                case Direction.Forward:
                    position.Horizontal += nav.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return position.DistanceTraveled.ToString();
    }
}

/// <summary>
///     Day two 2D navigation
/// </summary>
public class Day2Part2 : Day2 
{
    public Day2Part2(Input input) : base(2, 2, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        // Starts at 0,0,0
        var position = new Position();

        foreach (var nav in ReadNavigations())
        {
            switch (nav.Direction)
            {
                case Direction.Up:
                    position.Aim -= nav.Distance;
                    break;
                case Direction.Down:
                    position.Aim += nav.Distance;
                    break;
                case Direction.Forward:
                    position.Horizontal += nav.Distance;
                    position.Depth += position.Aim * nav.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return position.DistanceTraveled.ToString();
    }
}


public enum Direction {Up, Down, Forward}

/// <summary>
///     Navigation unit
/// </summary>
public struct Navigation
{
    /// <summary>
    ///     Direction of travel
    /// </summary>
    public Direction Direction;

    /// <summary>
    ///     Distance in units
    /// </summary>
    public int Distance;
}

/// <summary>
///     Position in 2D space
/// </summary>
public struct Position
{
    /// <summary>
    ///     Horizontal position in units relative to start
    /// </summary>
    public int Horizontal;
    
    
    /// <summary>
    ///     Depth in units relative to start
    /// </summary>
    public int Depth;

    /// <summary>
    ///     Angle of travel in units relative to start
    /// </summary>
    public int Aim;
    
    /// <summary>
    ///     Distance moved from start
    /// </summary>
    public int DistanceTraveled => Horizontal * Depth;
}