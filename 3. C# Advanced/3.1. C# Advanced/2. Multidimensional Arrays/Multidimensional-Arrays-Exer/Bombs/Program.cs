using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[squareMatrixSize, squareMatrixSize];
            for (int row = 0; row < squareMatrixSize; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < squareMatrixSize; column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            string[] stringCoordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string currentCoordinates in stringCoordinates)
            {
                int currentRow = currentCoordinates.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()[0];
                int currentCol = currentCoordinates.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()[1];
                int bombValue = matrix[currentRow, currentCol];
                if (bombValue > 0)
                {
                    for (int row = currentRow - 1; row < currentRow + 2; row++)
                    {
                        for (int col = currentCol - 1; col < currentCol + 2; col++)
                        {
                            if (AreIndexesValid(squareMatrixSize, row, col) && matrix[row, col] > 0)
                            {
                                matrix[row, col] -= bombValue;
                            }
                        }
                    }
                }
            }

            int aliveCellsCount = 0;
            int aliveCellsSum = 0;
            foreach (int element in matrix)
            {
                if (element > 0)
                {
                    aliveCellsCount++;
                    aliveCellsSum += element;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}{Environment.NewLine}Sum: {aliveCellsSum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool AreIndexesValid(int boardSize, int row, int column)
        {
            return row >= 0 && row < boardSize
                && column >= 0 && column < boardSize;
        }
    }
}
