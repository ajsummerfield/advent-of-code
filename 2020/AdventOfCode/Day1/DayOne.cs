namespace AdventOfCode.Day1
{
    using System;
    using System.Linq;
    using System.IO;

    public static class DayOne
    {
        public static int RunPartOne()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day1\\Input.txt");

            var inputList = input.Select(int.Parse).ToList();

            inputList.ForEach(number =>
            {
                var numCheck = 2020 - number;

                if (inputList.Contains(numCheck))
                {
                    result = number * numCheck;
                    return;
                }
            });

            return result;
        }

        public static int RunPartTwo()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day1\\Input.txt");

            var numbersFound = false;

            var inputList = input.Select(int.Parse).ToList();

            for (var i = 0; i < inputList.Count; i++)
            {
                if (numbersFound)
                {
                    break;
                }

                for (var j = i + 1; j < inputList.Count; j++)
                {
                    var number1 = inputList[i];
                    var number2 = inputList[j];

                    var numCheck = 2020 - (number1 + number2);

                    if (inputList.Contains(numCheck))
                    {
                        result = number1 * number2 * numCheck;
                        numbersFound = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
