using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                beach[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            int myTokens = 0;
            int opponentTokens = 0;
            string command = "";
            while ((command = Console.ReadLine()) != "Gong")
            {
                if (command.Contains("Find"))
                {
                    int[] coordinates = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();
                    int row = coordinates[0];
                    int col = coordinates[1];
                    myTokens += CollectToken(row, col, beach);
                }
                else if (command.Contains("Opponent"))
                {
                    string[] coordinatesAndDirection = command
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Skip(1)
                           .ToArray();
                    int row = int.Parse(coordinatesAndDirection[0]);
                    int col = int.Parse(coordinatesAndDirection[1]);
                    if (AreCoordinatesValid(row, col, beach))
                    {
                        opponentTokens += CollectToken(row, col, beach);
                        string direction = coordinatesAndDirection[2];
                        switch (direction)
                        {
                            case "up":
                                for (int i = 0; i < 3; i++)
                                {
                                    opponentTokens += CollectToken(--row, col, beach);
                                }
                                break;
                            case "down":
                                for (int i = 0; i < 3; i++)
                                {
                                    opponentTokens += CollectToken(++row, col, beach);
                                }
                                break;
                            case "left":
                                for (int i = 0; i < 3; i++)
                                {
                                    opponentTokens += CollectToken(row, --col, beach);
                                }
                                break;
                            case "right":
                                for (int i = 0; i < 3; i++)
                                {
                                    opponentTokens += CollectToken(row, ++col, beach);
                                }
                                break;
                        }
                    }
                }
            }

            foreach (char[] row in beach)
            {
                Console.WriteLine(string.Join(' ', row));
            }
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static bool AreCoordinatesValid(int row, int col, char[][] beach)
        {
            return row >= 0 && row < beach.Length &&
                col >= 0 && col < beach[row].Length;
        }

        static int CollectToken(int row, int col, char[][] beach)
        {
            int tokensCollected = 0;
            if (AreCoordinatesValid(row, col, beach) && beach[row][col] == 'T')
            {
                tokensCollected++;
                beach[row][col] = '-';
            }

            return tokensCollected;
        }
    }
}
