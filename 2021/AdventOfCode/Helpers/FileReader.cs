namespace AdventOfCode.Helpers
{
    using System;
    using System.IO;

    public static class FileReader
    {
        public static string[] Read(int day, bool useSample = false)
        {
            return File.ReadAllLines($"C:\\git\\advent-of-code\\2021\\AdventOfCode\\Day{day}\\{(useSample ? "Sample" : "Input")}.txt");
        }

        public static string[] SplitOnNewLines(int day, bool useSample = false)
        {
            var input = File.ReadAllText($"C:\\git\\advent-of-code\\2021\\AdventOfCode\\Day{day}\\{(useSample ? "Sample" : "Input")}.txt");

            return input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
