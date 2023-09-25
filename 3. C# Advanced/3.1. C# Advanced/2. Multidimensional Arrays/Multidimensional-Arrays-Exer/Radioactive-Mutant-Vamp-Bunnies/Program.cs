using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vamp_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] lair = new char[matrixSizes[0], matrixSizes[1]];
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine().ToUpper();
                for (int column = 0; column < lair.GetLength(1); column++)
                {
                    lair[row, column] = currentRow[column];
                    if (lair[row, column] == 'P')
                    {
                        startRow = row;
                        startCol = column;
                    }
                }
            }

            string commands = Console.ReadLine().ToUpper();
            bool playerWon = false;
            bool playerDied = false;
            foreach (char command in commands)
            {
                bool newIndexValid = false;
                lair[startRow, startCol] = '.';
                switch (command)
                {
                    case 'L':
                        if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), startRow, startCol - 1))
                        {
                            startCol -= 1;
                            newIndexValid = true;
                        }
                        break;
                    case 'R':
                        if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), startRow, startCol + 1))
                        {
                            startCol += 1;
                            newIndexValid = true;
                        }
                        break;
                    case 'U':
                        if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), startRow - 1, startCol))
                        {
                            startRow -= 1;
                            newIndexValid = true;
                        }
                        break;
                    case 'D':
                        if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), startRow + 1, startCol))
                        {
                            startRow += 1;
                            newIndexValid = true;
                        }
                        break;
                }

                if (newIndexValid)
                {
                    switch (lair[startRow, startCol])
                    {
                        case 'B':
                            playerDied = true;
                            break;
                        case '.':
                            lair[startRow, startCol] = 'P';
                            break;
                    }

                }
                else
                {
                    playerWon = true;
                }


                Queue<int> currentBunnyIndexes = new Queue<int>();
                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            currentBunnyIndexes.Enqueue(row);
                            currentBunnyIndexes.Enqueue(col);
                        }
                    }
                }

                while (currentBunnyIndexes.Count > 0)
                {
                    int row = currentBunnyIndexes.Dequeue();
                    int col = currentBunnyIndexes.Dequeue();
                    if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), row - 1, col))
                    {
                        if (lair[row - 1, col] == 'P')
                        {
                            playerDied = true;
                        }
                        lair[row - 1, col] = 'B';
                    }

                    if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), row + 1, col))
                    {
                        if (lair[row + 1, col] == 'P')
                        {
                            playerDied = true;
                        }
                        lair[row + 1, col] = 'B';
                    }

                    if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), row, col - 1))
                    {
                        if (lair[row, col - 1] == 'P')
                        {
                            playerDied = true;
                        }
                        lair[row, col - 1] = 'B';
                    }

                    if (AreIndexesValid(lair.GetLength(0), lair.GetLength(1), row, col + 1))
                    {
                        if (lair[row, col + 1] == 'P')
                        {
                            playerDied = true;
                        }
                        lair[row, col + 1] = 'B';
                    }
                }

                if (playerDied || playerWon)
                {
                    break;
                }
            }

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int column = 0; column < lair.GetLength(1); column++)
                {
                    Console.Write(lair[row, column]);
                }
                Console.WriteLine();
            }

            if (playerDied)
            {
                Console.WriteLine($"dead: {startRow} {startCol}");
            }
            else if (playerWon)
            {
                Console.WriteLine($"won: {startRow} {startCol}");
            }
        }

        static bool AreIndexesValid(int lairRows, int lairCols, int row, int column)
        {
            return row >= 0 && row < lairRows
                && column >= 0 && column < lairCols;
        }
    }
}
