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

            var result = 0;

            var sections = input.Select(x => x.Split(",").Select(y => Regex.Matches(y, @"\d+").Select(z => int.Parse(z.Value))).Select(a => GetSections(a))).ToList();

            sections.ForEach(s =>
            {

            });

            foreach (var pair in input)
            {
                var assignments = pair.Split(",");
                var a1Sections = assignments[0].Split("-").Select(int.Parse);
                var a2Sections = assignments[1].Split("-").Select(int.Parse);
                var a1SectionNums = GetSections(a1Sections);
                var a2SectionNums = GetSections(a2Sections);

                if (a1SectionNums.All(x => a2SectionNums.Contains(x)) || a2SectionNums.All(x => a1SectionNums.Contains(x)))
                {
                    result++;
                }
            }

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(4);

            var result = 0;

            foreach (var pair in input)
            {
                var assignments = pair.Split(",");
                var a1Sections = assignments[0].Split("-").Select(int.Parse);
                var a2Sections = assignments[1].Split("-").Select(int.Parse);
                var a1SectionNums = GetSections(a1Sections);
                var a2SectionNums = GetSections(a2Sections);

                if (a1SectionNums.Intersect(a2SectionNums).Any())
                {
                    result++;
                }
            }

            return result;
        }

        private static List<int> GetSections(IEnumerable<int> sections)
        {
            return Enumerable.Range(sections.First(), (sections.Last() - sections.First() + 1)).Select(i => i).ToList();
        }
    }
}
