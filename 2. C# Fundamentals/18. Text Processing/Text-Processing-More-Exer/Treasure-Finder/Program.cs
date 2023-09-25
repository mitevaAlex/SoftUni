using System;
using System.Linq;

namespace Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keyNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "find")
            {
                int keyCounter = -1;
                for (int i = 0; i < input.Length; i++)
                {
                    keyCounter++;
                    char newSymbol = (char)(input[i] - keyNumbers[keyCounter]);
                    input = input.Remove(i, 1);
                    input = input.Insert(i, newSymbol.ToString());
                    if (keyCounter == keyNumbers.Length - 1)
                    {
                        keyCounter = -1;
                    }
                }
                string[] inputDecryptedParts = input
                    .Split(new char[] { '&', '<', '>' });
                string coordinatesOrType = inputDecryptedParts[1];
                string typeTreasure = string.Empty;
                string coordinates = string.Empty;
                bool areArgsFound = false;
                for (int i = 0; i < coordinatesOrType.Length; i++)
                {
                    if (char.IsDigit(coordinatesOrType[i]))
                    {
                        typeTreasure = inputDecryptedParts[3];
                        coordinates = coordinatesOrType;
                        areArgsFound = true;
                    }
                }
                if (!areArgsFound)
                {
                    typeTreasure = coordinatesOrType;
                    coordinates = inputDecryptedParts[3];
                }
                Console.WriteLine($"Found {typeTreasure} at {coordinates}");
            }
        }
    }
}
