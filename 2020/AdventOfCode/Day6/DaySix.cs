namespace AdventOfCode.Day6
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public static class DaySix
    {
        public static int RunPartOne()
        {
            var result = 0;

            var input = File.ReadAllText("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day6\\Input.txt");

            var groups = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var group in groups)
            {
                var groupUpdated = group.Replace("\r\n", "").ToString();

                var count = string.Join("", groupUpdated.Distinct()).Length;

                result += count;
            }

            return result;
        }

        public static int RunPartTwo()
        {
            var result = 0;

            var input = File.ReadAllText("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day6\\Input.txt");

            var groups = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var group in groups)
            {
                var count = 0;

                if (group.Contains("\r\n"))
                {
                    var groupUpdated = group.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var questionsEveryoneAnswered = new List<char>();

                    foreach (var gu in groupUpdated)
                    {
                        var peoplesAnswers = gu.ToCharArray().ToList();

                        peoplesAnswers.ForEach(pa =>
                        {
                            if (groupUpdated.All(x => x.Contains(pa)) && !questionsEveryoneAnswered.Contains(pa))
                            {
                                questionsEveryoneAnswered.Add(pa);
                                count++;
                            }
                        });
                    }
                }
                else
                {
                    count = string.Join("", group.Distinct()).Length;
                }

                result += count;
            }

            return result;
        }
    }
}
