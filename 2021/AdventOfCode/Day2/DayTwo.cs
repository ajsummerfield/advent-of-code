namespace AdventOfCode
{
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayTwo
    {
        public static int RunPartOne()
        {
            var input = FileReader.Read(2);

            var inputList = input.Select(x =>
            {
                var line = x.Split(' ');
                return new
                {
                    Direction = line[0],
                    Amount = int.Parse(line[1])
                };
            }).ToList();

            var depth = 0;
            var horizontalPosition = 0;

            inputList.ForEach(command =>
            {
                switch (command.Direction)
                {
                    case "forward":
                        horizontalPosition += command.Amount;

                        break;
                    case "up":
                        depth -= command.Amount;

                        break;
                    case "down":
                        depth += command.Amount;

                        break;
                    default:
                        break;
                }
            });

            return depth * horizontalPosition;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.Read(2);

            var inputList = input.Select(x =>
            {
                var line = x.Split(' ');
                return new
                {
                    Direction = line[0],
                    Amount = int.Parse(line[1])
                };
            }).ToList();

            var depth = 0;
            var horizontalPosition = 0;
            var aim = 0;

            inputList.ForEach(command =>
            {
                switch (command.Direction)
                {
                    case "forward":
                        horizontalPosition += command.Amount;
                        depth += aim * command.Amount;

                        break;
                    case "up":
                        aim -= command.Amount;

                        break;
                    case "down":
                        aim += command.Amount;

                        break;
                    default:
                        break;
                };
            });

            return depth * horizontalPosition;
        }
    }
}
