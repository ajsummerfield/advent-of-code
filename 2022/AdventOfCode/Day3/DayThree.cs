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
                .Select(x => x.Chunk(x.Length / 2).ToList())
                .Select(y => y.First().FirstOrDefault(z => y.Last().Contains(z)))
                .Sum(x => GetLetterValue(x));

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(3);

            var result = input
                .Select((x, i) => input.Skip(i * 3).Take(3).ToList())
                .Where(x => x.Any())
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
