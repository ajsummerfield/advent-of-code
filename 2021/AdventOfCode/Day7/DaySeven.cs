namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Linq;

    public static class DaySeven
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(7);

            var crabHorizontalPositions = input[0].Split(',').Select(int.Parse).ToList();

            var leastFuel = int.MaxValue;

            var max = crabHorizontalPositions.Max();

            for (var i = 0; i < max; i++)
            {
                var fuelRequired = 0;

                for (var j = 0; j < crabHorizontalPositions.Count(); j++)
                {
                    var position = crabHorizontalPositions[j];
                    fuelRequired += Math.Abs(i - position);
                }

                if (fuelRequired < leastFuel)
                {
                    leastFuel = fuelRequired;
                }
            }

            var result = leastFuel;

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(7);

            var crabHorizontalPositions = input[0].Split(',').Select(int.Parse).ToList();

            var leastFuel = int.MaxValue;

            var max = crabHorizontalPositions.Max();

            for (var i = 0; i < max; i++)
            {
                var fuelRequired = 0;

                for (var j = 0; j < crabHorizontalPositions.Count(); j++)
                {
                    var position = crabHorizontalPositions[j];
                    var steps = Math.Abs(i - position);

                    //fuelRequired += Enumerable.Range(1, steps).Sum();
                    fuelRequired += steps * (steps + 1) / 2;
                }

                if (fuelRequired < leastFuel)
                {
                    leastFuel = fuelRequired;
                }
            }

            var result = leastFuel;

            return result;
        }
    }
}
