namespace AdventOfCode.Day7
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public static class DaySeven
    {
        public static int RunPartOne()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day7\\Input.txt");

            var instructions = input.ToList();

            var executedInstructions = new List<string>();

            var accumlator = 0;

            for (var i = 0; i < instructions.Count; i++)
            {
                var instruction = instructions[i];
                var line = instruction.Split(' ');
                var operation = line[0];
                var argument = line[1];

                if (!executedInstructions.Contains(i + ": " + instruction))
                {
                    if (operation == "acc")
                    {
                        accumlator += int.Parse(argument);
                    }
                    else if (operation == "jmp")
                    {
                        var offset = int.Parse(argument) - 1;
                        i += offset;
                    }

                    executedInstructions.Add(i + ": " + instruction);
                }
                else
                {
                    result = accumlator;
                    break;
                }
            }

            return result;
        }

        public static int RunPartTwo()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day7\\Sample.txt");

            var instructions = input.ToList();

            var executedInstructions = new List<string>();

            var accumlator = 0;

            for (var i = 0; i < instructions.Count; i++)
            {
                var instruction = instructions[i];
                var line = instruction.Split(' ');
                var operation = line[0];
                var argument = line[1];

                if (!executedInstructions.Contains(i + ": " + instruction))
                {
                    if (operation == "acc")
                    {
                        accumlator += int.Parse(argument);
                    }
                    else if (operation == "jmp")
                    {
                        var offset = int.Parse(argument) - 1;
                        i += offset;
                    }

                    executedInstructions.Add(i + ": " + instruction);
                }
                else
                {
                    result = accumlator;
                    break;
                }
            }

            return result;
        }
    }
}
