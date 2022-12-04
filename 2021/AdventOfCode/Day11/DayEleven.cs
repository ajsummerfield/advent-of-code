namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DayEleven
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(11);

            var octopuses = input.SelectMany(x => x.ToCharArray()).Select(x => int.Parse(x.ToString())).ToList();

            var result = 0;

            var rows = input.Length;

            var columns = input.FirstOrDefault().Length;

            var matrix = CreateMatrix(rows, columns, octopuses);

            var totalSteps = 100;

            var totalFlashes = 0;

            while (totalSteps > 0)
            {
                for (var y = 0; y < rows; y++)
                {
                    for (var x = 0; x < columns; x++)
                    {
                        matrix[y, x] += 1;
                    }
                }

                var flattenedMatrix = matrix.Cast<int>().ToArray();

                while(flattenedMatrix.Any(x => x > 9))
                {
                    for (var y = 0; y < rows; y++)
                    {
                        for (var x = 0; x < columns; x++)
                        {
                            totalFlashes += Flash(matrix, rows, columns, x, y);
                        }
                    }

                    flattenedMatrix = matrix.Cast<int>().ToArray();
                }

                for (var y = 0; y < rows; y++)
                {
                    for (var x = 0; x < columns; x++)
                    {
                        if (matrix[y, x] < 0)
                        {
                            matrix[y, x] = 0;
                        }
                    }
                }

                totalSteps--;
            }

            result = totalFlashes;

            return result;
        }

        public static long RunPartTwo()
        {
            var input = FileReader.Read(11);

            var octopuses = input.SelectMany(x => x.ToCharArray()).Select(x => int.Parse(x.ToString())).ToList();

            var result = 0;

            var rows = input.Length;

            var columns = input.FirstOrDefault().Length;

            var matrix = CreateMatrix(rows, columns, octopuses);

            var totalSteps = 0;

            var allFlashesFound = false;

            var flattenedMatrix = matrix.Cast<int>().ToArray();

            while (!allFlashesFound)
            {
                for (var y = 0; y < rows; y++)
                {
                    for (var x = 0; x < columns; x++)
                    {
                        matrix[y, x] += 1;
                    }
                }

                flattenedMatrix = matrix.Cast<int>().ToArray();

                while (flattenedMatrix.Any(x => x > 9))
                {
                    for (var y = 0; y < rows; y++)
                    {
                        for (var x = 0; x < columns; x++)
                        {
                            Flash(matrix, rows, columns, x, y);
                        }
                    }

                    flattenedMatrix = matrix.Cast<int>().ToArray();
                }

                for (var y = 0; y < rows; y++)
                {
                    for (var x = 0; x < columns; x++)
                    {
                        if (matrix[y, x] < 0)
                        {
                            matrix[y, x] = 0;
                        }
                    }
                }

                flattenedMatrix = matrix.Cast<int>().ToArray();

                if (flattenedMatrix.All(x => x == 0))
                {
                    allFlashesFound = true;
                }

                totalSteps++;
            }

            result = totalSteps;

            return result;
        }

        private static int[,] CreateMatrix(int rows, int columns, List<int> input)
        {
            var matrix = new int[rows, columns];
            var rowJump = 0;

            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < columns; x++)
                {
                    matrix[y, x] = input[rowJump + y + x];
                }

                rowJump += columns - 1;
            }

            return matrix;
        }

        private static int Flash(int[,] matrix, int rows, int columns, int x, int y)
        {
            var location = matrix[y, x];

            if (location > 9)
            {
                var top = y > 0 ? matrix[y - 1, x] += 1 : 0;
                var topRight = y > 0 && x < columns - 1 ? matrix[y - 1, x + 1] += 1 : 0;
                var topLeft = y > 0 && x > 0 ? matrix[y - 1, x - 1] += 1 : 0;
                var right = x < columns - 1 ? matrix[y, x + 1] += 1 : 0;
                var bottom = y < rows - 1 ? matrix[y + 1, x] += 1 : 0;
                var bottomRight = y < rows - 1 && x < columns - 1 ? matrix[y + 1, x + 1] += 1 : 0;
                var bottomLeft = y < rows - 1 && x > 0 ? matrix[y + 1, x - 1] += 1 : 0;
                var left= x > 0 ? matrix[y, x - 1] += 1 : 0;

                matrix[y, x] = int.MinValue;
                return 1;
            }

            return 0;
        }
    }
}
