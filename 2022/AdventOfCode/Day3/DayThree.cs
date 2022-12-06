namespace AdventOfCode
{
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayThree
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(3);

            var result = input
                .Select(x => x.Substring(0, x.Length / 2).ToCharArray().FirstOrDefault(y => x.Substring(x.Length / 2, x.Length / 2).Contains(y)))
                .Sum(x => GetLetterValue(x));

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(3);

            var groups = input.Select((s, i) => input.Skip(i * 3).Take(3).ToList()).Where(a => a.Any()).ToList();

            var result = groups
                .Select(x => x.Select((y, i) => y.ToCharArray().FirstOrDefault(z => x[i + 1].Contains(z) && x[i + 2].Contains(z))).FirstOrDefault())
                .Sum(x => GetLetterValue(x));

            return result;
        }

        private static int GetLetterValue(char letter)
        {
            return letter > 96 ? letter - 96 : letter - 38;
        }
    }
}
