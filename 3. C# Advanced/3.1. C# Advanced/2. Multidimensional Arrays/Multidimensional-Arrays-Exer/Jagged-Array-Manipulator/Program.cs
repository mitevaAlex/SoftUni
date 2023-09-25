using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] jaggedArray = new double[int.Parse(Console.ReadLine())][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x * 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArray[row] = jaggedArray[row].Select(x => x / 2).ToArray();
                    jaggedArray[row + 1] = jaggedArray[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                int[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(int.Parse)
                    .ToArray();
                int row = commandArgs[0];
                int column = commandArgs[1];
                int value = commandArgs[2];
                if (command.Contains("Add") && AreIndexesValid(jaggedArray, row, column))
                {
                    jaggedArray[row][column] += value;
                }
                else if (command.Contains("Subtract") && AreIndexesValid(jaggedArray, row, column))
                {
                    jaggedArray[row][column] -= value;
                }
            }

            foreach (double[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        static bool AreIndexesValid (double[][] jaggedArray, int row, int column)
        {
            return !(row < 0 || row >= jaggedArray.Length
                || column < 0 || column >= jaggedArray[row].Length);
        }
    }
}
