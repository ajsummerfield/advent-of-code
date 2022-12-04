namespace AdventOfCode
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayTwo
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(2);

            var rounds = input.Select(x => new
            {
                Opponent = x.Split(" ")[0],
                You = x.Split(" ")[1]
            }).ToList();

            var result = 0;

            rounds.ForEach(round =>
            {
                if (round.Opponent == "A" && round.You == "X" ||
                    round.Opponent == "B" && round.You == "Y" ||
                    round.Opponent == "C" && round.You == "Z")
                {
                    result += 3;
                }

                if (round.You == "X" && round.Opponent == "C" ||
                    round.You == "Y" && round.Opponent == "A" ||
                    round.You == "Z" && round.Opponent == "B")
                {
                    result += 6;
                }

                result += round.You switch
                {
                    "X" => 1,
                    "Y" => 2,
                    "Z" => 3,
                    _ => throw new ArgumentException("Invalid Choice!")
                };
            });

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(2);

            var rounds = input.Select(x => new
            {
                Opponent = x.Split(" ")[0],
                You = x.Split(" ")[1]
            }).ToList();

            var result = 0;

            rounds.ForEach(round =>
            {
                var choice = string.Empty;

                result += round.Opponent switch
                {
                    "A" => round.You == "X" ? 3 : round.You == "Y" ? 4 : 8,
                    "B" => round.You == "X" ? 1 : round.You == "Y" ? 5 : 9,
                    "C" => round.You == "X" ? 2 : round.You == "Y" ? 6 : 7,
                    _ => throw new ArgumentException("Invalid Choice!")
                };
            });

            return result;
        }
    }
}
