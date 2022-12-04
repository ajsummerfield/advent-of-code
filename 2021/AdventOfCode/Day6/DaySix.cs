namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Linq;

    public static class DaySix
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(6);

            var lanternFishAges = input[0].Split(',').Select(int.Parse).ToList();

            var result = 0;

            var totalFishToday = lanternFishAges.Count();

            for (var i = 0; i < 80; i++)
            {
                for (var j = 0; j < totalFishToday; j++)
                {
                    var fishAge = lanternFishAges[j];

                    if (fishAge == 0)
                    {
                        lanternFishAges[j] = 6;
                        lanternFishAges.Add(8);
                    }
                    else
                    {
                        lanternFishAges[j] -= 1;
                    }
                }

                totalFishToday = lanternFishAges.Count();
            }

            result = totalFishToday;

            return result;
        }

        public static decimal RunPartTwo()
        {
            var input = FileReader.Read(6);

            var lanternFishAges = input[0].Split(',').Select(int.Parse).ToList();

            var fishLifeCycleDays = 9;

            var fishesInLifeCycle = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            lanternFishAges.ForEach(x => fishesInLifeCycle[x]++);

            for (var i = 0; i < 256; i++)
            {
                var newLanternFish = fishesInLifeCycle[0];

                Enumerable.Range(0, fishLifeCycleDays - 1)
                    .ToList()
                    .ForEach(x => fishesInLifeCycle[x] = fishesInLifeCycle[x + 1]);

                fishesInLifeCycle[fishLifeCycleDays - 3] += newLanternFish;
                fishesInLifeCycle[fishLifeCycleDays - 1] = newLanternFish;
            }

            return fishesInLifeCycle.Sum();
        }
    }
}
