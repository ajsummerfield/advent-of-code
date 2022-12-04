namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayThree
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(3, true);

            var inputList = input.Select(x => x).ToList();

            var numberSize = inputList.First().Length;

            var gammaBinaryNumber = string.Empty;

            for (var i = 0; i < numberSize; i++)
            {
                var newNumbers = inputList.Select(number => number.ToString()[i]);

                var result = newNumbers.GroupBy(x => x)
                    .Select(x => new { Key = x.Key, Count = x.Count() })
                    .OrderByDescending(x => x.Count)
                    .FirstOrDefault();

                gammaBinaryNumber += result.Key;
            }

            var gammaRate = Convert.ToInt32(gammaBinaryNumber, 2);
            var epsilonBinaryNumber = string.Join("", gammaBinaryNumber.Select(x => x == '1' ? '0' : '1').ToArray());
            var epsilonRate = Convert.ToInt32(epsilonBinaryNumber, 2);

            return gammaRate * epsilonRate;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(3);

            var inputList = input.Select(x => x).ToList();

            var numberSize = inputList.First().Length;

            inputList = RunThroughInput(numberSize, inputList, '1');

            var oxygenGeneratorRating = Convert.ToInt32(inputList.First(), 2);

            inputList = input.Select(x => x).ToList();

            inputList = RunThroughInput(numberSize, inputList, '0');

            var co2ScrubberRating = Convert.ToInt32(inputList.First(), 2);

            return oxygenGeneratorRating * co2ScrubberRating;
        }

        private static List<string> RunThroughInput(int numberSize, List<string> inputList, char value)
        {
            for (var i = 0; i < numberSize; i++)
            {
                var newNumbers = inputList.Select(number => number.ToString()[i]);

                var numbers = newNumbers.GroupBy(x => x)
                    .Select(x => new { Key = x.Key, Count = x.Count() });

                numbers = value == '0' ? numbers.OrderBy(x => x.Count) : numbers.OrderByDescending(x => x.Count);

                var sameCount = numbers.FirstOrDefault().Count == numbers.LastOrDefault().Count;

                inputList = inputList
                    .Where(number => number.ElementAt(i) == (sameCount ? value : numbers.First().Key))
                    .ToList();

                if (inputList.Count == 1)
                {
                    break;
                }
            }

            return inputList;
        }
    }
}
