namespace Advent2021.Core;

/// <summary>
///     Base puzzle type
/// </summary>
public abstract class BasePuzzle
{
    protected readonly Input _puzzleInput;

    /// <summary>
    ///     Create a new puzzle
    /// </summary>
    /// <param name="day">Puzzle id</param>
    /// <param name="part">For multi-part days</param>
    /// <param name="input">Pre-allocated input data</param>
    protected BasePuzzle(int day, int part, Input input)
    {
        Day = day;
        Name = $"Day {day}.{part}";
        _puzzleInput = input;
    }
    
    /// <summary>
    ///     Puzzle day number
    /// </summary>
    public int Day { get; }
    
    /// <summary>
    ///     Name of this puzzle
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Solve problem and return result as string
    /// </summary>
    /// <returns>Puzzle solution</returns>
    public abstract string Solve();

    /// <summary>
    ///     Read input as a list of integers
    /// </summary>
    /// <returns>Input lines as integers</returns>
    protected IEnumerable<int> ReadIntegers()
    {
        return _puzzleInput.Select(int.Parse);
    }
}