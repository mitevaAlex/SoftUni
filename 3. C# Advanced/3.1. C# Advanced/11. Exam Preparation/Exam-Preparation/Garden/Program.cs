using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenDimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] garden = new int[gardenDimensions[0], gardenDimensions[1]];
            string command = "";
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (AreCoordinatesValid(gardenDimensions, coordinates))
                {
                    garden[coordinates[0], coordinates[1]] = -1;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    if (garden[row, col] == -1)
                    {
                        BloomAllFlowers(row, col, garden);
                    }
                }
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool AreCoordinatesValid(int[] gardenDimensions, int[] coordinates)
        {
            return coordinates[0] < gardenDimensions[0] && coordinates[0] >= 0 &&
                coordinates[1] < gardenDimensions[1] && coordinates[1] >= 0;
        }

        static void BloomAllFlowers(int row, int col, int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(1); i++)
            {
                garden[row, i]++;
            }

            for (int i = 0; i < garden.GetLength(0); i++)
            {
                garden[i, col]++;
            }
        }
    }
}
