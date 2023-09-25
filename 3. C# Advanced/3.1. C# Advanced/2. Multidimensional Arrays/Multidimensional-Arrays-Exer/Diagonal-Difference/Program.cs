using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[squareMatrixSize, squareMatrixSize];
            for (int row = 0; row < squareMatrixSize; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int column = 0; column < squareMatrixSize; column++)
                {
                    squareMatrix[row, column] = currentRow[column];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            for (int rowAndCol = 0; rowAndCol < squareMatrixSize; rowAndCol++)
            {
                primaryDiagonalSum += squareMatrix[rowAndCol, rowAndCol];
            }

            for (int row = squareMatrixSize - 1; row >= 0; row--)
            {
                secondaryDiagonalSum += squareMatrix[row, squareMatrixSize - row - 1];
            }

            int absoluteDiagonalDifference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(absoluteDiagonalDifference);
        }
    }
}
