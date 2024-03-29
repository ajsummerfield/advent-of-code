﻿namespace AdventOfCode
{
    using System;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayTwo
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(2);

            var result = 0;

            input.ToList().ForEach(round =>
            {
                result += round switch
                {
                    "A X" => 3 + 1,
                    "A Y" => 6 + 2,
                    "A Z" => 0 + 3,
                    "B X" => 0 + 1,
                    "B Y" => 3 + 2,
                    "B Z" => 6 + 3,
                    "C X" => 6 + 1,
                    "C Y" => 0 + 2,
                    "C Z" => 3 + 3,
                    _ => throw new ArgumentException("Invalid Choice!")
                };
            });

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(2);

            var result = 0;

            input.ToList().ForEach(round =>
            {
                var choice = string.Empty;

                result += round switch
                {
                    "A X" => 0 + 3,
                    "A Y" => 3 + 1,
                    "A Z" => 6 + 2,
                    "B X" => 0 + 1,
                    "B Y" => 3 + 2,
                    "B Z" => 6 + 3,
                    "C X" => 0 + 2,
                    "C Y" => 3 + 3,
                    "C Z" => 6 + 1,
                    _ => throw new ArgumentException("Invalid Choice!")
                };
            });

            return result;
        }
    }
}
