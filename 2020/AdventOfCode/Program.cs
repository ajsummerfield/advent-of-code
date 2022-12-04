namespace AdventOfCode
{
    using AdventOfCode.Day1;
    using AdventOfCode.Day2;
    using AdventOfCode.Day3;
    using AdventOfCode.Day5;
    using AdventOfCode.Day6;
    using AdventOfCode.Day7;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var partOneResult = DaySeven.RunPartOne();
            Console.WriteLine($"Part One Result: {partOneResult}");

            var partTwoResult = DaySeven.RunPartTwo();
            Console.WriteLine($"Part Two Result: {partTwoResult}");
        }
    }
}
