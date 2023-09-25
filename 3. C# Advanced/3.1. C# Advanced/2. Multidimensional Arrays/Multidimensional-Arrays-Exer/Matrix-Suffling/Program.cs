using System;
using System.Linq;

namespace Matrix_Suffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[matrixSizes[0], matrixSizes[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] != "swap" || commandArgs.Length > 5 || commandArgs.Length < 5
                    || int.Parse(commandArgs[1]) < 0 || int.Parse(commandArgs[1]) >= matrixSizes[0]
                    || int.Parse(commandArgs[2]) < 0 || int.Parse(commandArgs[2]) >= matrixSizes[1]
                    || int.Parse(commandArgs[3]) < 0 || int.Parse(commandArgs[3]) >= matrixSizes[0]
                    || int.Parse(commandArgs[4]) < 0 || int.Parse(commandArgs[4]) >= matrixSizes[1])
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string firstElement = matrix[int.Parse(commandArgs[1]), int.Parse(commandArgs[2])];
                    string secondElement = matrix[int.Parse(commandArgs[3]), int.Parse(commandArgs[4])];
                    matrix[int.Parse(commandArgs[1]), int.Parse(commandArgs[2])] = secondElement;
                    matrix[int.Parse(commandArgs[3]), int.Parse(commandArgs[4])] = firstElement;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int column = 0; column < matrix.GetLength(1); column++)
                        {
                            Console.Write($"{matrix[row, column]} ");
                        }
                        
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
