namespace AdventOfCode.Day2
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public static class DayTwo
    {
        public static int RunPartOne()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day2\\Input.txt");

            var inputList = input.ToList();

            var allowedPasswords = new List<string>();

            foreach (var row in inputList)
            {
                var policy = row.Split(": ")[0];
                var password = row.Split(": ")[1];

                var policyParts = policy.Split(" ")[0];
                var policyLetter = Convert.ToChar(policy.Split(" ")[1]);
                var min = int.Parse(policyParts.Split("-")[0]);
                var max = int.Parse(policyParts.Split("-")[1]);

                var letterOccurence = password.Count(x => (x == policyLetter));

                if (letterOccurence >= min && letterOccurence <= max)
                {
                    allowedPasswords.Add(row);
                }
            }

            result = allowedPasswords.Count;


            return result;
        }

        public static int RunPartTwo()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day2\\Input.txt");

            var inputList = input.ToList();

            var allowedPasswords = new List<string>();

            foreach (var row in inputList)
            {
                var policy = row.Split(": ")[0];
                var password = row.Split(": ")[1];

                var policyParts = policy.Split(" ")[0];
                var policyLetter = Convert.ToChar(policy.Split(" ")[1]);
                var pos1 = int.Parse(policyParts.Split("-")[0]) - 1;
                var pos2 = int.Parse(policyParts.Split("-")[1]) - 1;

                if ((password[pos1] == policyLetter && password[pos2] != policyLetter) || (password[pos1] != policyLetter && password[pos2] == policyLetter))
                {
                    allowedPasswords.Add(row);
                }
            }

            result = allowedPasswords.Count;

            return result;
        }
    }
}
