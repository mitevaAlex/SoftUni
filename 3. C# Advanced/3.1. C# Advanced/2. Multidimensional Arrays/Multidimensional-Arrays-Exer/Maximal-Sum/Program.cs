using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = ReadArray();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = ReadArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxColumn = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    int currentSum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2]
                        + matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2]
                        + matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxColumn = column;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int column = maxColumn; column < maxColumn + 3; column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }

                Console.WriteLine();
            }
        }

        static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
