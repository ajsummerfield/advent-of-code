namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Linq;

    public static class DayFive
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(5);

            var lineSegments = input.Select(x =>
            {
                var line = x.Split(" -> ");
                var startCoordinates = line[0].Split(',').Select(int.Parse);
                var endCoordinates = line[1].Split(',').Select(int.Parse);

                return new LineSegment
                {
                    Start = new Coordinate(startCoordinates.First(), startCoordinates.Last()),
                    End = new Coordinate(endCoordinates.First(), endCoordinates.Last())
                };
            }).ToList();

            var result = 0;

            var matrixSize = 1000; // lineSegments.Count;

            var matrix = new int[matrixSize, matrixSize];

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            lineSegments.ForEach(ls =>
            {
                if (ls.Start.X == ls.End.X || ls.Start.Y == ls.End.Y)
                {
                    if (ls.Start.X == ls.End.X)
                    {
                        var min = Math.Min(ls.Start.Y, ls.End.Y);
                        var max = Math.Max(ls.Start.Y, ls.End.Y);

                        for (var y = min; y <= max; y++)
                        {
                            matrix[ls.Start.X, y] += 1;
                        }
                    }

                    if (ls.Start.Y == ls.End.Y)
                    {
                        var min = Math.Min(ls.Start.X, ls.End.X);
                        var max = Math.Max(ls.Start.X, ls.End.X);

                        for (var x = min; x <= max; x++)
                        {
                            matrix[x, ls.Start.Y] += 1;
                        }
                    }
                }
            });

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j] >= 2)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(5);

            var lineSegments = input.Select(x =>
            {
                var line = x.Split(" -> ");
                var startCoordinates = line[0].Split(',').Select(int.Parse);
                var endCoordinates = line[1].Split(',').Select(int.Parse);

                return new LineSegment
                {
                    Start = new Coordinate(startCoordinates.First(), startCoordinates.Last()),
                    End = new Coordinate(endCoordinates.First(), endCoordinates.Last())
                };
            }).ToList();

            var result = 0;

            var matrixSize = 1000; // lineSegments.Count;

            var matrix = new int[matrixSize, matrixSize];

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            lineSegments.ForEach(ls =>
            {
                if (ls.Start.X == ls.End.X || ls.Start.Y == ls.End.Y)
                {
                    if (ls.Start.X == ls.End.X)
                    {
                        var minY = Math.Min(ls.Start.Y, ls.End.Y);
                        var maxY = Math.Max(ls.Start.Y, ls.End.Y);

                        for (var y = minY; y <= maxY; y++)
                        {
                            matrix[ls.Start.X, y] += 1;
                        }
                    }

                    if (ls.Start.Y == ls.End.Y)
                    {
                        var minX = Math.Min(ls.Start.X, ls.End.X);
                        var maxX = Math.Max(ls.Start.X, ls.End.X);

                        for (var x = minX; x <= maxX; x++)
                        {
                            matrix[x, ls.Start.Y] += 1;
                        }
                    }
                }
                else
                {
                    var diff = Math.Abs(ls.Start.X - ls.End.X);

                    matrix[ls.Start.X, ls.Start.Y] += 1;

                    var xPos = ls.Start.X;
                    var yPos = ls.Start.Y;

                    for (var i = 0; i < diff; i++)
                    {
                        xPos += ls.Start.X > ls.End.X ? -1 : 1;
                        yPos += ls.Start.Y > ls.End.Y ? -1 : 1;

                        matrix[xPos, yPos] += 1;
                    }
                }
            });

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j] >= 2)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }

    public class LineSegment
    {
        public Coordinate Start { get; set; }

        public Coordinate End { get; set; }
    }

    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
