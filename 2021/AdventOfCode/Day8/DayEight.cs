namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DayEight
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(8);

            var entries = input.Select(x => new Entry(x)).ToList();

            var result = 0;

            entries.ForEach(entry =>
            {
                entry.Digits.ForEach(digit =>
                {
                    if (digit.Length == 2 || digit.Length == 4 ||
                        digit.Length == 3 || digit.Length == 7)
                    {
                        result++;
                    }
                });
            });

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(8);

            var entries = input.Select(x => new Entry(x)).ToList();

            var result = 0;

            var displaySegments = new string[7];

            var zero = string.Empty;
            var lettersInSegmentOne = string.Empty;
            var two = string.Empty;
            var lettersInSegmentThree = string.Empty;
            var lettersInSegmentFour = string.Empty;
            var five = string.Empty;
            var lettersInSegmentSix = string.Empty;
            var lettersInSegmentSeven = string.Empty;
            var lettersInSegmentEight = string.Empty;
            var letterInSegmentsNine = string.Empty;

            var patternsOfFive = new List<string>();
            var patternsOfSix = new List<string>();

            entries.ForEach(entry =>
            {
                entry.Patterns.ForEach(pattern =>
                {
                    switch (pattern.Length)
                    {
                        case 2:
                            lettersInSegmentOne = pattern;
                            break;
                        case 3:
                            lettersInSegmentSeven = pattern;
                            break;
                        case 4:
                            lettersInSegmentFour = pattern;
                            break;
                        case 5:
                            patternsOfFive.Add(pattern);
                            break;
                        case 6:
                            patternsOfSix.Add(pattern);
                            break;
                        case 7:
                            lettersInSegmentEight = pattern;
                            break;
                        default:
                            break;
                    }
                });

                displaySegments[0] = lettersInSegmentSeven.Except(lettersInSegmentOne).First().ToString();

                patternsOfSix.ForEach(pattern =>
                {
                    if (pattern.Except(lettersInSegmentSeven.Concat(lettersInSegmentFour)).Count() == 1)
                    {
                        letterInSegmentsNine = pattern;
                    }

                    if (pattern.Except(lettersInSegmentSeven).Count() == 4)
                    {
                        lettersInSegmentSix = pattern;
                    }
                });

                displaySegments[2] = lettersInSegmentEight.Except(lettersInSegmentSix).First().ToString();
                displaySegments[4] = lettersInSegmentEight.Except(letterInSegmentsNine).First().ToString();
                displaySegments[6] =
                    lettersInSegmentEight.Except(lettersInSegmentSeven.Concat(lettersInSegmentFour).Concat(displaySegments[4])).First().ToString();

                patternsOfFive.ForEach(pattern =>
                {
                    if (pattern.Except(lettersInSegmentSeven.Concat(displaySegments[6])).Count() == 1)
                    {
                        lettersInSegmentThree = pattern;
                        displaySegments[3] = pattern.Except(lettersInSegmentSeven.Concat(displaySegments[6])).First().ToString();
                    }
                });

                displaySegments[1] = lettersInSegmentEight.Except(lettersInSegmentThree.Concat(displaySegments[4])).First().ToString();
                displaySegments[5] = lettersInSegmentOne.Except(displaySegments[2]).First().ToString();

                result += entry.CalculateOutput(displaySegments);
            });

            return result;
        }
    }

    public class Entry
    {
        public Entry(string entry)
        {
            this.Patterns = this.GetEntryData(entry, 0);
            this.Digits = this.GetEntryData(entry, 1);
        }

        public List<string> Patterns { get; set; }

        public List<string> Digits { get; set; }

        public int CalculateOutput(string[] displaySegments)
        {
            var output = string.Empty;

            this.Digits.ForEach(digit =>
            {
                if (digit.Length == 2)
                {
                    output += 1;
                }

                if (digit.Length == 3)
                {
                    output += 7;
                }

                if (digit.Length == 4)
                {
                    output += 4;
                }

                if (digit.Length == 5)
                {
                    if (digit.Contains(displaySegments[1]))
                    {
                        output += 5;
                    }
                    else if (digit.Contains(displaySegments[4]))
                    {
                        output += 2;
                    }
                    else
                    {
                        output += 3;
                    }
                }

                if (digit.Length == 6)
                {
                    if (!digit.Contains(displaySegments[4]))
                    {
                        output += 9;
                    }
                    else if (!digit.Contains(displaySegments[2]))
                    {
                        output += 6;
                    }
                    else
                    {
                        output += 0;
                    }
                }

                if (digit.Length == 7)
                {
                    output += 8;
                }
            });

            return int.Parse(output);
        }

        private List<string> GetEntryData(string entry, int position)
        {
            return entry.Split('|')[position].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }
    }
}
