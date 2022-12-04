namespace AdventOfCode
{
    using AdventOfCode.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DayTen
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(10);

            var inputList = input.ToList();

            var result = 0;

            inputList.ForEach(line =>
            {
                var lineContainsPairs = line.Contains("()") || line.Contains("[]") || 
                                        line.Contains("{}") || line.Contains("<>");
                
                while (lineContainsPairs)
                {
                    line = line.Replace("()", string.Empty)
                        .Replace("[]", string.Empty)
                        .Replace("{}", string.Empty)
                        .Replace("<>", string.Empty);

                    lineContainsPairs = line.Contains("()") || line.Contains("[]") ||
                                        line.Contains("{}") || line.Contains("<>");
                }

                var lineContainsClosingCharacter = line.Contains(")") || line.Contains("]") ||
                                        line.Contains("}") || line.Contains(">");

                if (lineContainsClosingCharacter)
                {
                    var incorrectCharacter = line.FirstOrDefault(x => x != '(' && x != '[' && x != '{' && x != '<');

                    result += incorrectCharacter switch
                    {
                        ')' => 3,
                        ']' => 57,
                        '}' => 1197,
                        '>' => 25137,
                        _ => 0
                    };
                }
            });

            return result;
        }

        public static long RunPartTwo()
        {
            var input = FileReader.Read(10);

            var inputList = input.ToList();

            var result = 0L;

            var scores = new List<long>();

            inputList.ForEach(line =>
            {
                var lineContainsPairs = line.Contains("()") || line.Contains("[]") ||
                                        line.Contains("{}") || line.Contains("<>");

                var strippedLine = line;

                while (lineContainsPairs)
                {
                    strippedLine = strippedLine.Replace("()", string.Empty)
                        .Replace("[]", string.Empty)
                        .Replace("{}", string.Empty)
                        .Replace("<>", string.Empty);

                    lineContainsPairs = strippedLine.Contains("()") || strippedLine.Contains("[]") ||
                                        strippedLine.Contains("{}") || strippedLine.Contains("<>");
                }

                var lineContainsClosingCharacter = strippedLine.Contains(")") || strippedLine.Contains("]") ||
                                        strippedLine.Contains("}") || strippedLine.Contains(">");

                if (!lineContainsClosingCharacter)
                {
                    var strippedLineReversed = strippedLine.Reverse();

                    var score = 0L;

                    foreach (var character in strippedLineReversed)
                    {
                        score *= 5;

                        score += character switch
                        {
                            '(' => 1,
                            '[' => 2,
                            '{' => 3,
                            '<' => 4,
                            _ => 0
                        };
                    }

                    scores.Add(score);
                }
            });

            scores.Sort();

            result = scores[scores.Count / 2];

            return result;
        }
    }
}
