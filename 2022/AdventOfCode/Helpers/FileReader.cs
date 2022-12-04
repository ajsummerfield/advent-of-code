namespace AdventOfCode.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileReader
    {
        public static string[] Read(int day, bool useSample = false)
        {
            return File.ReadAllLines($"C:\\git\\advent-of-code\\2022\\AdventOfCode\\Day{day}\\{(useSample ? "Sample" : "Input")}.txt");
        }

        public static string[] SplitOnNewLines(int day, bool useSample = false)
        {
            var input = File.ReadAllText($"C:\\git\\advent-of-code\\2022\\AdventOfCode\\Day{day}\\{(useSample ? "Sample" : "Input")}.txt");
            return input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static List<string[]> GroupByBlankLines(int day, bool useSample = false)
        {
            var splitInput = SplitOnNewLines(day, useSample);
            return splitInput.Select(x => x.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)).ToList();

        }
    }
}
