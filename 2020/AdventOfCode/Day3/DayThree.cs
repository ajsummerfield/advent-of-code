namespace AdventOfCode.Day3
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;

    public static class DayThree
    {
        public static int RunPartOne()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day3\\Input.txt");

            var xPos = 0;
            var yPos = 0;

            var openSquares = new List<string>();
            var trees = new List<string>();

            for (var i = 0; i < input.Length; i++)
            {
                xPos += 1;
                yPos += 2;

                i = yPos;

                var newRow = input[i];
                var newRowLength = newRow.Length;

                var newRowsToMake = (int)Math.Floor((double)xPos / newRow.Length);
                var sb = new StringBuilder(newRow, newRowsToMake * newRow.Length);

                if (xPos >= newRowLength)
                {
                    for (var j = 0; j < newRowsToMake; j++)
                    {
                        sb.Append(newRow);
                    }
                }

                var builtRow = sb.ToString();

                var square = builtRow[xPos];

                if (square == '.')
                {
                    openSquares.Add(builtRow);
                }

                if (square == '#')
                {
                    trees.Add(builtRow);
                }
            }

            result = trees.Count;

            return result;
        }

        public static int RunPartTwo()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day3\\Input.txt");

            var inputList = input.ToList();

            return result;
        }
    }
}
