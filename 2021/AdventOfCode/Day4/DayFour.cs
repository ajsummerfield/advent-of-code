namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode.Helpers;

    public static class DayFour
    {
        public static int RunPartOne()
        {
            var input = FileReader.SplitOnNewLines(4);

            var bingoNumbers = input[0].Split(',').Select(int.Parse).ToList();

            var bingoBoardNumbers = input.Skip(1).Select(x => x.Split("\r\n").ToList()).ToList();

            var bingoBoards = GenerateBoards(bingoBoardNumbers);

            var result = 0;

            bingoNumbers.ForEach(bingoNumber =>
            {
                if (result == 0)
                {
                    bingoBoards.ForEach(board =>
                    {
                        if (result == 0 && board.Contains(bingoNumber))
                        {
                            var (winner, unmarkedNumbersSum) = board.GetWinningInfo();
                            if (winner)
                            {
                                result = bingoNumber * unmarkedNumbersSum;
                            }
                        }
                    });
                }
                else
                {
                    return;
                }
            });

            return result;
        }

        public static int RunPartTwo()
        {
            var input = FileReader.SplitOnNewLines(4);

            var bingoNumbers = input[0].Split(',').Select(int.Parse).ToList();

            var bingoBoardNumbers = input.Skip(1).Select(x => x.Split("\r\n").ToList()).ToList();

            var bingoBoards = GenerateBoards(bingoBoardNumbers);

            var result = 0;

            var winningBoards = new List<BingoBoard>();
            var lastBingoNumber = 0;

            bingoNumbers.ForEach(bingoNumber =>
            {
                bingoBoards.ForEach(board =>
                {
                    if (!board.HasWon && board.Contains(bingoNumber))
                    {
                        var (winner, unmarkedNumbersSum) = board.GetWinningInfo();
                        if (winner)
                        {
                            lastBingoNumber = bingoNumber;
                            winningBoards.Add(board);
                        }
                    }
                });
            });

            var lastBoard = winningBoards.LastOrDefault();
            var (winner, unmarkedNumbersSum) = lastBoard.GetWinningInfo();
            result = lastBingoNumber * unmarkedNumbersSum;

            return result;
        }

        private static List<BingoBoard> GenerateBoards(List<List<string>> bingoBoardNumbers)
        {
            var bingoBoards = new List<BingoBoard>();

            bingoBoardNumbers.ForEach(boardNumbers =>
            {
                var board = new BingoBoardNumber[5, 5];

                var numbers = boardNumbers
                    .SelectMany(x => x.Split(' '))
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(int.Parse).ToList();

                var rowJump = 0;

                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        board[i, j] = new BingoBoardNumber()
                        {
                            Number = numbers[rowJump + i + j]
                        };
                    }

                    rowJump += 4;
                }

                bingoBoards.Add(new BingoBoard()
                {
                    Board = board
                });
            });

            return bingoBoards;
        }
    }

    public class BingoBoard
    {
        public BingoBoardNumber[,] Board { get; set; }

        public bool HasWon { get; set; }

        public bool Contains(int number)
        {
            var numberFound = false;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (this.Board[i,j].Number == number)
                    {
                        this.Board[i, j].Marked = true;
                        numberFound = true;
                        break;
                    }
                }
            }

            return numberFound;
        }

        public Tuple<bool, int> GetWinningInfo()
        {
            var rowWin = new List<bool>();
            var columnWin = new List<bool>();
            var winnerFound = false;
            var unmarkedNumbersSum = 0;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (!winnerFound && this.Board[i, j].Marked)
                    {
                        rowWin.Add(true);
                    }
                    if (!winnerFound && this.Board[j, i].Marked)
                    {
                        columnWin.Add(true);
                    }

                    if (!this.Board[i, j].Marked)
                    {
                        unmarkedNumbersSum += this.Board[i, j].Number;
                        rowWin.Add(false);
                        columnWin.Add(false);
                    }
                }

                if (rowWin.Count(x => x) == 5 || columnWin.Count(x => x) == 5)
                {
                    winnerFound = true;
                }
                else
                {
                    rowWin = new List<bool>();
                    columnWin = new List<bool>();
                }
            }

            this.HasWon = winnerFound;

            return new Tuple<bool, int>(winnerFound, unmarkedNumbersSum);
        }
    }

    public class BingoBoardNumber
    {
        public int Number { get; set; }

        public bool Marked { get; set; }
    }
}
