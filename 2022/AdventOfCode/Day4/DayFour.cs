namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayFour
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(4);

            var result = 0;

            foreach (var pair in input)
            {
                var assignments = pair.Split(",");
                var a1Sections = assignments[0].Split("-").Select(int.Parse);
                var a2Sections = assignments[1].Split("-").Select(int.Parse);

                if ((a1Sections.First() >= a2Sections.First() && a1Sections.Last() <= a2Sections.Last()) ||
                    (a2Sections.First() >= a1Sections.First() && a2Sections.Last() <= a1Sections.Last()))
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

                if ((a1Sections.First() >= a2Sections.First() && a1Sections.Last() <= a2Sections.Last()) ||
                    (a2Sections.First() >= a1Sections.First() && a2Sections.Last() <= a1Sections.Last()))
                {
                    result++;
                }
                else
                {
                    var a1SectionNums = GetSections(a1Sections);
                    var a2SectionNums = GetSections(a2Sections);

                    if (a1SectionNums.Any(c => a2SectionNums.Contains(c)))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private static List<int> GetSections(IEnumerable<int> sections)
        {
            var sectionNums = new List<int>();

            for (var i = sections.First(); i <= sections.Last(); i++)
            {
                sectionNums.Add(i);
            };

            return sectionNums;
        }
    }
}
