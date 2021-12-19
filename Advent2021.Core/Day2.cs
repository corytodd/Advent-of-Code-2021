namespace Advent2021.Core;

/// <summary>
///     Day 2 puzzles
/// </summary>
public abstract class Day2 : BasePuzzle
{
    protected Day2(int part, Input input) : base(2, part, input)
    {
    }

    /// <summary>
    ///     Interpret source file as navigation data
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException">File contains invalid data</exception>
    protected IEnumerable<Navigation> ReadNavigations()
    {
        return from line in _puzzleInput
            let parts = line.Split(" ")
            let direction = parts[0] switch
            {
                "forward" => Direction.Forward,
                "down" => Direction.Down,
                "up" => Direction.Up,
                _ => throw new ArgumentOutOfRangeException(line)
            }
            select new Navigation(direction, int.Parse(parts[1]));
    }

    protected enum Direction
    {
        Up,
        Down,
        Forward
    }

    /// <summary>
    ///     Navigation unit
    /// </summary>
    protected record Navigation(Direction Direction, int Distance);

    /// <summary>
    ///     Position in 2D space
    /// </summary>
    protected record Position
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
}

/// <summary>
///     Day two 2D navigation
/// </summary>
public class Day2Part1 : Day2
{
    public Day2Part1(Input input) : base(1, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        // Starts at 0,0
        var position = new Position();

        foreach (var (direction, distance) in ReadNavigations())
        {
            switch (direction)
            {
                case Direction.Up:
                    position.Depth -= distance;
                    break;
                case Direction.Down:
                    position.Depth += distance;
                    break;
                case Direction.Forward:
                    position.Horizontal += distance;
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
    public Day2Part2(Input input) : base(2, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        // Starts at 0,0,0
        var position = new Position();

        foreach (var (direction, distance) in ReadNavigations())
        {
            switch (direction)
            {
                case Direction.Up:
                    position.Aim -= distance;
                    break;
                case Direction.Down:
                    position.Aim += distance;
                    break;
                case Direction.Forward:
                    position.Horizontal += distance;
                    position.Depth += position.Aim * distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return position.DistanceTraveled.ToString();
    }
}