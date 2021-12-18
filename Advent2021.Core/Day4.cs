namespace Advent2021.Core;

using System.Text;

public abstract class Day4 : BasePuzzle
{
    protected Day4(int part, Input input) : base(4, part, input)
    {
    }

    /// <summary>
    ///     Returns boards parsed from input
    /// </summary>
    public IEnumerable<Board> ReadBoards()
    {
        // Skip drawn line
        foreach (var lines in _puzzleInput
                     .Skip(1)
                     .Chunk(6))
        {
            // Skip first empty line
            var boardData = lines.Skip(1)
                .SelectMany(s => s.Split(' '))
                .Where(s => int.TryParse(s, out _))
                .Select(int.Parse);
            yield return new Board(boardData);
        }
    }

    /// <summary>
    ///     Returns drawn values from puzzle input
    /// </summary>
    public IEnumerable<int> DrawnValues()
    {
        var line = _puzzleInput.First();
        foreach (var value in line.Split(',').Select(int.Parse))
        {
            yield return value;
        }
    }
}

/// <summary>
///     Bitmapping
/// </summary>
public class Day4Part1 : Day4
{
    public Day4Part1(Input input) : base(1, input)
    {
    }

    /// <inheritdoc />
    public override string Solve()
    {
        Board? winningBoard = null;

        var allBoards = ReadBoards().ToList();

        // Play all boards in parallel
        foreach (var drawn in DrawnValues())
        {
            // Play moves first
            foreach (var board in allBoards)
            {
                board.Play(drawn);
            }

            // No winners, keep playing
            if (!allBoards.Any(b => b.HasWin()))
            {
                continue;
            }

            // Take the board with the highest score
            winningBoard = allBoards.MaxBy(b => b.Score());
            break;
        }

        return winningBoard?.Score().ToString() ?? string.Empty;
    }
}

/// <summary>
///     A board's state can be represented in 25 bits
///     5 rows and 5 columns
/// </summary>
public class Board
{
    private const int Rows = 5;
    private const int Cols = 5;

    private readonly HashSet<BoardPosition> _layouts;
    private int? _lastDrawn;
    private int? _score;

    public Board(IEnumerable<int> values)
    {
        _layouts = new HashSet<BoardPosition>(25);

        var r = 0;
        var c = 0;
        foreach (var value in values)
        {
            _layouts.Add(new BoardPosition
            {
                Row = r,
                Col = c,
                Value = value
            });
            if (++c == Cols)
            {
                c = 0;
                ++r;
            }
        }
    }

    /// <summary>
    ///     Play the next drawn number
    /// </summary>
    /// <param name="drawn">Drawn bingo value</param>
    public void Play(int drawn)
    {
        _lastDrawn = drawn;

        foreach (var match in _layouts.Where(p => p.Value == drawn))
        {
            match.Marked = true;
        }
    }

    /// <summary>
    ///     Returns true if a win condition has been achieved
    /// </summary>
    public bool HasWin()
    {
        var hasWin = false;

        // Check rows
        for (var row = 0; row < Rows && !hasWin; ++row)
        {
            hasWin = _layouts
                .Where(p => p.Row == row)
                .All(p => p.Marked);
        }

        // Check columns
        for (var col = 0; col < Cols && !hasWin; ++col)
        {
            hasWin = _layouts
                .Where(p => p.Col == col)
                .All(p => p.Marked);
        }

        return hasWin;
    }

    /// <summary>
    ///     Apply scoring rules to this board
    ///     If there is no win, 0 is returned
    /// </summary>
    /// <returns>Score of this board</returns>
    public int Score()
    {
        if (!HasWin() || _lastDrawn is null)
        {
            return 0;
        }

        if (_score.HasValue)
        {
            return _score.Value;
        }

        var sum = _layouts
            .Where(p => !p.Marked)
            .Select(p => p.Value)
            .Sum();

        _score = sum * _lastDrawn;
        return _score.Value;
    }
}

public record BoardPosition
{
    public int Row { get; init; }
    public int Col { get; init; }
    public int Value { get; init; }
    public bool Marked { get; set; }
}