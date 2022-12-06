namespace AdventOfCode
{
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DaySix
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(6).FirstOrDefault();

            var result = input.Select((x, i) => input.Skip(i).Take(4).Distinct().Count() == 4 ? i + 4 : 0).FirstOrDefault(x => x != 0);

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(6).FirstOrDefault();

            var result = input.Select((x, i) => input.Skip(i).Take(14).Distinct().Count() == 14 ? i + 14 : 0).FirstOrDefault(x => x != 0);

            return result;
        }
    }
}
