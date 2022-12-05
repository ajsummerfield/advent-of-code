namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using AdventOfCode.Helpers;

    public static class DayFive
    {
        public static string RunPartOne()
        {
            var input = FileReader.Read(5).ToList();

            var stacks = GetStacks(input);

            var instructions = GetInstructions(input);

            instructions.ForEach(instruction =>
            {
                var moveAmount = instruction[0];
                var fromStack = instruction[1] - 1;
                var toStack = instruction[2] - 1;

                var crates = stacks[fromStack].GetRange(0, moveAmount);
                stacks[fromStack].RemoveRange(0, moveAmount);

                crates.Reverse();
                stacks[toStack].InsertRange(0, crates);
            });

            return string.Join(string.Empty, stacks.Select(x => x.First()));
        }

        public static string RunPartTwo()
        {
            var input = FileReader.Read(5).ToList();

            var stacks = GetStacks(input);

            var instructions = GetInstructions(input);

            instructions.ForEach(instruction =>
            {
                var moveAmount = instruction[0];
                var fromStack = instruction[1] - 1;
                var toStack = instruction[2] - 1;

                var crates = stacks[fromStack].GetRange(0, moveAmount);
                stacks[fromStack].RemoveRange(0, moveAmount);

                stacks[toStack].InsertRange(0, crates);
            });

            return string.Join(string.Empty, stacks.Select(x => x.First()));
        }

        private static List<List<string>> GetStacks(List<string> input)
        {
            var crates = new List<string>();
            var numberOfStacks = int.Parse(input[input.IndexOf(string.Empty) - 1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());

            for (var i = 0; i < input.IndexOf(string.Empty) - 1; i++)
            {
                var row = input[i];
                crates.Add(row.Replace("    [", "[.] [").Replace("]    ", "] [.]").Replace("    ", " [.]"));
            }

            var stacks = Enumerable.Range(0, numberOfStacks).Select(i => new List<string>()).ToList();

            for (var i = 0; i < crates.Count; i++)
            {
                var cratesArray = crates[i].Split(" ");

                for (var j = 0; j < cratesArray.Length; j++)
                {
                    var crate = cratesArray[j];
                    if (crate != "[.]")
                    {
                        stacks[j].Add(crate);
                    }
                }
            }

            return stacks;
        }

        private static List<List<int>> GetInstructions(List<string> input)
        {
            var instructions = input.Skip(input.IndexOf(string.Empty) + 1).ToList();
            return instructions.Select(x => Regex.Matches(x, @"\d+").Select(y => int.Parse(y.Value)).ToList()).ToList();
        }
    }
}
