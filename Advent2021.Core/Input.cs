namespace Advent2021.Core;

using System.Collections;
using System.Text;

public class Input : IEnumerable<string>
{
    private readonly IEnumerable<string> _inputLines;

    /// <summary>
    ///     Create a new input from a file
    /// </summary>
    /// <param name="inputFile">Source file</param>
    public Input(FileSystemInfo inputFile)
    {
        _inputLines = File.ReadAllLines(inputFile.FullName);
    }

    public Input(IEnumerable<string> inputLines)
    {
        _inputLines = inputLines;
    }

    /// <inheritdoc />
    public IEnumerator<string> GetEnumerator()
    {
        return _inputLines.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}