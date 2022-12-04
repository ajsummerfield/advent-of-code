namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DayTwelve
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(12, true);

            var caveConnections = input.ToList();

            var paths = new List<List<string>>();

            caveConnections.ForEach(caveConnection =>
            {
                var path = new List<string>();
                var cave1 = caveConnection.Split('-')[0];
                var cave2 = caveConnection.Split('-')[1];

                path.Add("start");

                path.Add("end");

                paths.Add(path);
            });

            var result = 0;

            return result;
        }

        public static long RunPartTwo()
        {
            var input = FileReader.Read(12, true);

            var result = 0;

            return result;
        }
    }
}
