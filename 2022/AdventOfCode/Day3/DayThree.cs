namespace AdventOfCode
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayThree
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(3);

            var result = 0;

            foreach (var rucksack in input)
            {
                var halfLength = rucksack.Length / 2;
                var comp1 = rucksack.Substring(0, halfLength);
                var comp2 = rucksack.Substring(halfLength, halfLength);

                var matchedLetter = comp1.ToCharArray().FirstOrDefault(c => comp2.Contains(c)).ToString();
                result += GetLetterValue(matchedLetter);
            }

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(3);

            var groups = input.Select((s, i) => input.Skip(i * 3).Take(3).ToList()).Where(a => a.Any()).ToList();

            var result = 0;

            groups.ForEach(group =>
            {
                var r1 = group[0];
                var r2 = group[1];
                var r3 = group[2];
                var matchedLetter = r1.ToCharArray().FirstOrDefault(c => r2.Contains(c) && r3.Contains(c)).ToString();
                result += GetLetterValue(matchedLetter);
            });

            return result;
        }

        private static int GetLetterValue(string letter)
        {
            var sum = 0;
            var upperLetter = letter.ToUpper();

            for (var i = 0; i < upperLetter.Length; i++)
            {
                sum = sum * 26 + upperLetter[i] - 64;
            }

            return upperLetter == letter ? sum + 26 : sum;
        }
    }
}
