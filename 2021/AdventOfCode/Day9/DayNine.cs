namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DayNine
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(9);

            var heightmap = input.SelectMany(x => x.ToCharArray()).Select(x => int.Parse(x.ToString())).ToList();

            var result = 0;

            var rows = input.Length;

            var columns = input.FirstOrDefault().Length;

            var matrix = CreateMatrix(rows, columns, heightmap);

            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < columns; x++)
                {
                    result += CheckAdjacentLocations(matrix, rows, columns, x, y);
                }
            }

           return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(9);

            var heightmap = input.SelectMany(x => x.ToCharArray()).Select(x => int.Parse(x.ToString())).ToList();

            var result = 0;

            var rows = input.Length;

            var columns = input.FirstOrDefault().Length;

            var matrix = CreateMatrix(rows, columns, heightmap);

            var lowPoints = new List<Coordinate>();

            var basins = new List<HashSet<Coordinate>>();

            for (var y = 0; y < rows; y++)
            {
                var count = 0;

                for (var x = 0; x < columns; x++)
                {
                    if (IsLowPoint(matrix, rows, columns, x, y))
                    {
                        lowPoints.Add(new Coordinate(x, y));
                    }

                    count++;
                }
            }

            lowPoints.ForEach(lowPoint =>
            {
                var emptyBasin = new HashSet<Coordinate>();
                var basin = FillBasin(matrix, lowPoint, emptyBasin, rows, columns);

                basins.Add(basin);
            });

            var orderedBasins = basins.OrderByDescending(x => x.Count);

            result = orderedBasins.ElementAt(0).Count * orderedBasins.ElementAt(1).Count * orderedBasins.ElementAt(2).Count;

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

        private static int CheckAdjacentLocations(int[,] matrix, int rows, int columns, int x, int y)
        {
            if (IsLowPoint(matrix, rows, columns, x, y))
            {
                return matrix[y, x] + 1;
            }

            return 0;
        }

        private static bool IsLowPoint(int[,] matrix, int rows, int columns, int x, int y)
        {
            var location = matrix[y, x];

            var topLower = y <= 0 || location < matrix[y - 1, x];
            var rightLower = x >= columns - 1 || location < matrix[y, x + 1];
            var bottomLower = y >= rows - 1 || location < matrix[y + 1, x];
            var leftLower = x <= 0 || location < matrix[y, x - 1];

            return topLower && rightLower && bottomLower && leftLower;
        }

        private static HashSet<Coordinate> FillBasin(int[,] matrix, Coordinate co, HashSet<Coordinate> basin, int rows, int columns)
        {
            if (!basin.Any(c => c.X == co.X && c.Y == co.Y) && matrix[co.Y, co.X] != 9)
            {
                basin.Add(co);

                foreach (var adj in GetAdjacent(co, rows, columns))
                {
                    foreach (var adjBasin in FillBasin(matrix, adj, basin, rows, columns))
                    {
                        basin.Add(adjBasin);
                    }
                };
            }

            return basin;
        }

        private static HashSet<Coordinate> GetAdjacent(Coordinate current, int rows, int columns)
        {
            var x = current.X;
            var y = current.Y;
            var adjacent = new HashSet<Coordinate>();

            if (y > 0)
            {
                adjacent.Add(new Coordinate(x, y - 1));
            }
            
            if (x < columns - 1)
            {
                adjacent.Add(new Coordinate(x + 1, y));
            }

            if (y < rows - 1)
            {
                adjacent.Add(new Coordinate(x, y + 1));
            }

            if (x > 0)
            {
                adjacent.Add(new Coordinate(x - 1, y));
            }

            return adjacent;
        }
    }
}
