namespace AdventOfCode
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var partOneResult = DayTwo.RunPartOne();
            Console.WriteLine($"Part One Result: {partOneResult}");

            var partTwoResult = DayTwo.RunPartTwo();
            Console.WriteLine($"Part Two Result: {partTwoResult}");
        }
    }
}
