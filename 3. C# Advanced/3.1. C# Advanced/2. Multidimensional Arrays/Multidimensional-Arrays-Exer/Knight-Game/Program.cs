using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareBoardSize = int.Parse(Console.ReadLine());
            char[,] board = new char[squareBoardSize, squareBoardSize];
            for (int row = 0; row < squareBoardSize; row++)
            {
                string currentRow = Console.ReadLine().ToUpper();
                for (int column = 0; column < squareBoardSize; column++)
                {
                    board[row, column] = currentRow[column];
                }
            }

            int knightsToRemove = 0;
            while (true)
            {
                int maxKills = 0;
                int maxRow = 0;
                int maxCol = 0;
                for (int row = 0; row < squareBoardSize; row++)
                {
                    for (int column = 0; column < squareBoardSize; column++)
                    {
                        if (board[row, column] == 'K')
                        {
                            int kills = KillsCount(board, row, column);
                            if (kills > maxKills)
                            {
                                maxKills = kills;
                                maxRow = row;
                                maxCol = column;
                            }
                        }
                    }
                }

                if (maxKills > 0)
                {
                    board[maxRow, maxCol] = '0';
                    knightsToRemove++;
                }
                else
                {
                    break;
                }
            }
            
            Console.WriteLine(knightsToRemove);
        }

        static bool AreIndexesValid(int boardSize, int row, int column)
        {
            return row >= 0 && row < boardSize
                && column >= 0 && column < boardSize;
        }

        static int KillsCount(char[,] board, int row, int col)
        {
            int kills = 0;
            if (AreIndexesValid(board.GetLength(0), row + 1, col - 2) && 'K' == board[row + 1, col - 2])
            {
                kills++;
            }

            if (AreIndexesValid(board.GetLength(0), row + 1, col + 2) && 'K' == board[row + 1, col + 2])
            {
                kills++;
            }

            if (AreIndexesValid(board.GetLength(0), row + 2, col - 1) && 'K' == board[row + 2, col - 1])
            {
                kills++;
            }

            if (AreIndexesValid(board.GetLength(0), row + 2, col + 1) && 'K' == board[row + 2, col + 1])
            {
                kills++;
            }

            if (AreIndexesValid(board.GetLength(0), row - 1, col - 2) && 'K' == board[row - 1, col - 2])
            {
                kills++;
            }

            if (AreIndexesValid(board.GetLength(0), row - 1, col + 2) && 'K' == board[row - 1, col + 2])
            {
                kills++;
            }

            if (AreIndexesValid(board.GetLength(0), row - 2, col - 1) && 'K' == board[row - 2, col - 1])
            {
                kills++;
            }

            if (AreIndexesValid(board.GetLength(0), row - 2, col + 1) && 'K' == board[row - 2, col + 1])
            {
                kills++;
            }

            return kills;
        }
    }
}
