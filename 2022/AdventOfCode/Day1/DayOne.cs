namespace AdventOfCode
{
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayOne
    {
        public static int RunPartOne()
        {
            var input = FileReader.GroupByBlankLines(1);

            var result = input.Select(x => x.Sum(y => int.Parse(y))).Max();

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.GroupByBlankLines(1);

            var result = input.Select(x => x.Sum(y => int.Parse(y))).ToList();

            result.Sort((a, b) => b.CompareTo(a));

            return result.GetRange(0, 3).Sum();
        }
    }
}
