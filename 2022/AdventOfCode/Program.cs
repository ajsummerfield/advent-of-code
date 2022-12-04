namespace AdventOfCode
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var partOneResult = DayThree.RunPartOne();
            Console.WriteLine($"Part One Result: {partOneResult}");

            var partTwoResult = DayThree.RunPartTwo();
            Console.WriteLine($"Part Two Result: {partTwoResult}");
        }
    }
}
