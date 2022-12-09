namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DaySeven
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(7, true).ToList();

            var system = new Dictionary<string, List<string>>();

            var directories = new List<string>();

            var currentDir = string.Empty;

            input.ForEach(x =>
            {
                if (x.StartsWith("$ cd"))
                {
                    var cdRequest = x.Split(" ").Last();

                    if (cdRequest == "..")
                    {
                        var currentDirIndex = directories.IndexOf(currentDir);
                        currentDir = directories[currentDirIndex - 1];
                        return;
                    }

                    currentDir = x.Split(" ").Last();

                    if (!system.ContainsKey(currentDir))
                    {
                        system.Add(currentDir, new List<string>());
                        directories.Add(currentDir);
                    }
                }

                if (!x.StartsWith("$"))
                {
                    system.GetValueOrDefault(currentDir).Add(x);
                }
            });

            var result = 0;

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(7, true).ToList();

            var result = 0;

            return result;
        }
    }
}
