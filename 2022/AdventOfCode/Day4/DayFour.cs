namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using AdventOfCode.Helpers;

    public static class DayFour
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(4);

            var result = input
                .Select(x => x.Split(",").Select(y => Regex.Matches(y, @"\d+").Select(z => int.Parse(z.Value))).Select(a => GetSections(a)))
                .Select(x => x.First().All(y => x.Last().Contains(y)) || x.Last().All(y => x.First().Contains(y)) ? 1 : 0)
                .Sum();

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(4);

            var result = input
                .Select(x => x.Split(",").Select(y => Regex.Matches(y, @"\d+").Select(z => int.Parse(z.Value))).Select(a => GetSections(a)))
                .Select(x => x.First().Intersect(x.Last()).Any() ? 1 : 0)
                .Sum();

            return result;
        }

        private static List<int> GetSections(IEnumerable<int> sections)
        {
            return Enumerable.Range(sections.First(), (sections.Last() - sections.First() + 1)).Select(i => i).ToList();
        }
    }
}
