namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DaySeven
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(7).ToList();

            var system = new Dictionary<string, List<string>>();

            var directories = new Dictionary<string, int>();

            var currentDir = string.Empty;

            var path = "/";

            input.ForEach(x =>
            {
                if (x.StartsWith("$ cd"))
                {
                    if (x.Split(" ").Last() == "..")
                    {
                        path = path.Remove(path.IndexOf(currentDir + "/"), currentDir.Length + 1);
                        currentDir = path != "/" ? path.Split("/").Last(x => x != string.Empty) : "/";
                        return;
                    }

                    currentDir = x.Split(" ").Last();

                    if (currentDir != "/")
                    {
                        path = path + currentDir + "/";
                    }

                    if (!system.ContainsKey(path))
                    {
                        system.Add(path, new List<string>());
                        directories.Add(path, 0);
                    }
                }

                if (!x.StartsWith("$"))
                {
                    system.GetValueOrDefault(path).Add(x);

                    if (!x.Contains("dir"))
                    {
                        var fileSize = int.Parse(x.Split(" ").First());
                        var currentDirSize = directories.GetValueOrDefault(path);
                        directories.Remove(path);
                        directories.Add(path, currentDirSize + fileSize);
                    }
                }
            });

            foreach (var dir in system.Reverse())
            {
                var innerDirs = dir.Value.FindAll(x => x.Contains("dir")).Select(x => $"{dir.Key}{x.Split(" ").Last()}/");

                if (innerDirs.Any())
                {
                    var innerDirsSize = directories.Where(x => innerDirs.Contains(x.Key)).Sum(x => x.Value);

                    if (innerDirsSize > 0)
                    {
                        var currentDirSize = directories.GetValueOrDefault(dir.Key);

                        directories.Remove(dir.Key);
                        directories.Add(dir.Key, currentDirSize + innerDirsSize);
                    }
                }
            }

            var result = directories.Where(x => x.Value < 100000).Sum(x => x.Value);

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(7).ToList();

            var system = new Dictionary<string, List<string>>();

            var directories = new Dictionary<string, int>();

            var currentDir = string.Empty;

            var path = "/";

            input.ForEach(x =>
            {
                if (x.StartsWith("$ cd"))
                {
                    if (x.Split(" ").Last() == "..")
                    {
                        path = path.Remove(path.IndexOf(currentDir + "/"), currentDir.Length + 1);
                        currentDir = path != "/" ? path.Split("/").Last(x => x != string.Empty) : "/";
                        return;
                    }

                    currentDir = x.Split(" ").Last();

                    if (currentDir != "/")
                    {
                        path = path + currentDir + "/";
                    }

                    if (!system.ContainsKey(path))
                    {
                        system.Add(path, new List<string>());
                        directories.Add(path, 0);
                    }
                }

                if (!x.StartsWith("$"))
                {
                    system.GetValueOrDefault(path).Add(x);

                    if (!x.Contains("dir"))
                    {
                        var fileSize = int.Parse(x.Split(" ").First());
                        var currentDirSize = directories.GetValueOrDefault(path);
                        directories.Remove(path);
                        directories.Add(path, currentDirSize + fileSize);
                    }
                }
            });

            foreach (var dir in system.Reverse())
            {
                var innerDirs = dir.Value.FindAll(x => x.Contains("dir")).Select(x => $"{dir.Key}{x.Split(" ").Last()}/");

                if (innerDirs.Any())
                {
                    var innerDirsSize = directories.Where(x => innerDirs.Contains(x.Key)).Sum(x => x.Value);

                    if (innerDirsSize > 0)
                    {
                        var currentDirSize = directories.GetValueOrDefault(dir.Key);

                        directories.Remove(dir.Key);
                        directories.Add(dir.Key, currentDirSize + innerDirsSize);
                    }
                }
            }

            var remainingSpace = 70000000 - directories.FirstOrDefault().Value;

            var requiredExtraSpace = 30000000 - remainingSpace;

            var result = directories.OrderByDescending(x => x.Value).Reverse().FirstOrDefault(x => x.Value > requiredExtraSpace).Value;
            
            return result;
        }
    }
}
