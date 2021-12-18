using Advent2021.Core;

Console.WriteLine("Advent of Code :: 2021 :: corytodd");

var puzzles = new[]
{
    new Day1(new Input(new FileInfo("data/day_1_input.txt")))
};

foreach (var puzzle in puzzles)
{
    var solution = puzzle.Solve();
    Console.WriteLine($"{puzzle.Name} solution: {solution}");
}