namespace AdventOfCode.Day5
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public static class DayFive
    {
        public static int RunPartOne()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day5\\Input.txt");

            var seats = input.ToList();

            var seatIds = new List<int>();

            foreach (var seat in seats)
            {
                var binary = ConvertToBinary(seat);

                // var row = Convert.ToInt32(binary.Substring(0, 7), 2);
                // var column = Convert.ToInt32(binary.Substring(7, 3), 2);
                // var seatId = row * 8 + column;

                var seatId = Convert.ToInt32(binary, 2);

                seatIds.Add(seatId);
            }

            result = seatIds.Max();

            return result;
        }

        public static int RunPartTwo()
        {
            var result = 0;

            var input = File.ReadAllLines("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day5\\Input.txt");

            var seats = input.ToList();

            var seatIds = new List<int>();

            foreach (var seat in seats)
            {
                var binary = ConvertToBinary(seat);

                // var row = Convert.ToInt32(binary.Substring(0, 7), 2);
                // var column = Convert.ToInt32(binary.Substring(7, 3), 2);
                // var seatId = row * 8 + column;

                var seatId = Convert.ToInt32(binary, 2);

                seatIds.Add(seatId);
            }

            seatIds.Sort();

            var prevSeatId = seatIds.First() - 1;

            foreach (var seatId in seatIds)
            {
                if (seatId - prevSeatId == 2)
                {
                    result = seatId - 1;
                    break;
                }

                prevSeatId = seatId;
            }

            return result;
        }

        private static string ConvertToBinary(string seat)
        {
            return seat.Replace("F", "0")
                       .Replace("B", "1")
                       .Replace("R", "1")
                       .Replace("L", "0");
        }
    }
}
