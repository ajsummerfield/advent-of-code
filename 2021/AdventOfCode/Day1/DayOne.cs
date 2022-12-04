namespace AdventOfCode
{
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayOne
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(1);

            var inputList = input.Select(int.Parse).ToList();

            var result = inputList.Select((number, index) =>
            {
                if (index < inputList.Count - 1 && number < inputList[index + 1])
                {
                    return 1;
                }

                return 0;
            }).Sum();

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(1);

            var inputList = input.Select(int.Parse).ToList();

            var result = inputList.Select((number, index) =>
            {
                if (index > 0 && index < inputList.Count - 2)
                {
                    var cur = number + inputList[index + 1] + inputList[index + 2];
                    var prev = inputList[index - 1] + number + inputList[index + 1];
                    if (cur > prev)
                    {
                        prev = cur;
                        return 1;
                    }
                }

                return 0;
            }).Sum();

            return result;
        }
    }
}
