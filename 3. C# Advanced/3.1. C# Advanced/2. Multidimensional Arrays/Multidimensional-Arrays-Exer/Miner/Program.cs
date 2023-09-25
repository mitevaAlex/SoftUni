using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[squareMatrixSize, squareMatrixSize];
            int startRow = 0;
            int startCol = 0;
            int allCoal = 0;
            for (int row = 0; row < squareMatrixSize; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToUpper()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int column = 0; column < squareMatrixSize; column++)
                {
                    field[row, column] = currentRow[column];
                    if (field[row, column] == 'S')
                    {
                        startRow = row;
                        startCol = column;
                    }
                    else if (field[row, column] == 'C')
                    {
                        allCoal++;
                    }
                }
            }

            int coalCollected = 0;
            bool newIndexValid = false;
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "LEFT":
                        if (AreIndexesValid(squareMatrixSize, startRow, startCol - 1))
                        {
                            startCol -= 1;
                            newIndexValid = true;
                        }
                        break;
                    case "RIGHT":
                        if (AreIndexesValid(squareMatrixSize, startRow, startCol + 1))
                        {
                            startCol += 1;
                            newIndexValid = true;
                        }
                        break;
                    case "UP":
                        if (AreIndexesValid(squareMatrixSize, startRow - 1, startCol))
                        {
                            startRow -= 1;
                            newIndexValid = true;
                        }
                        break;
                    case "DOWN":
                        if (AreIndexesValid(squareMatrixSize, startRow + 1, startCol))
                        {
                            startRow += 1;
                            newIndexValid = true;
                        }
                        break;
                }


                if (newIndexValid)
                {
                    switch (field[startRow, startCol])
                    {
                        case 'C':
                            coalCollected++;
                            field[startRow, startCol] = '*';
                            break;
                        case 'E':
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                    }
                }

                if (allCoal == coalCollected)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }

            Console.WriteLine($"{allCoal - coalCollected} coals left. ({startRow}, {startCol})");
        }

        static bool AreIndexesValid(int boardSize, int row, int column)
        {
            return row >= 0 && row < boardSize
                && column >= 0 && column < boardSize;
        }
    }
}
