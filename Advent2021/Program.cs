using Advent2021.Core;

Console.WriteLine("Advent of Code :: 2021 :: corytodd");

BasePuzzle[] puzzles = {
    new Day1Part1(new Input(new FileInfo("data/day1_input.txt"))),
    new Day1Part2(new Input(new FileInfo("data/day1_input.txt"))),
    new Day2Part1(new Input(new FileInfo("data/day2_input.txt"))),
    new Day2Part2(new Input(new FileInfo("data/day2_input.txt"))),
    new Day3Part1(new Input(new FileInfo("data/day3_input.txt"))),
    new Day3Part2(new Input(new FileInfo("data/day3_input.txt"))),
    new Day4Part1(new Input(new FileInfo("data/day4_input.txt"))),
    new Day4Part2(new Input(new FileInfo("data/day4_input.txt"))),
    new Day5Part1(new Input(new FileInfo("data/day5_input.txt"))),
    new Day5Part2(new Input(new FileInfo("data/day5_input.txt"))),
    new Day6Part1(new Input(new FileInfo("data/day6_input.txt"))),
    new Day6Part2(new Input(new FileInfo("data/day6_input.txt")))
};

foreach (var puzzle in puzzles)
{
    var solution = puzzle.Solve();
    Console.WriteLine($"{puzzle.Name} solution: {solution}");
}