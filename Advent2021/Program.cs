using Advent2021.Core;

Console.WriteLine("Advent of Code :: 2021 :: corytodd");

BasePuzzle[] puzzles = {
    new Day1Part1(new Input(new FileInfo("data/day1_1_input.txt"))),
    new Day1Part2(new Input(new FileInfo("data/day1_2_input.txt")))
};

foreach (var puzzle in puzzles)
{
    var solution = puzzle.Solve();
    Console.WriteLine($"{puzzle.Name} solution: {solution}");
}