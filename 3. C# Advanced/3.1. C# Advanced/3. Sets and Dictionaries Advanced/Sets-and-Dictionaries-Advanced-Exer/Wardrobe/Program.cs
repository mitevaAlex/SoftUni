using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothesCounts = new Dictionary<string, Dictionary<string, int>>();
            int colorsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < colorsCount; i++)
            {
                string[] currentClothes = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = currentClothes[0];
                if (!clothesCounts.ContainsKey(color))
                {
                    clothesCounts.Add(color, new Dictionary<string, int>());
                }

                foreach (string pieceOfClothing in currentClothes.Skip(1))
                {
                    if (!clothesCounts[color].ContainsKey(pieceOfClothing))
                    {
                        clothesCounts[color].Add(pieceOfClothing, 0);
                    }

                    clothesCounts[color][pieceOfClothing]++;
                }
            }

            string[] wantedClothing = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var color in clothesCounts)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var pieceOfClothing in color.Value)
                {
                    if (color.Key == wantedClothing[0] && pieceOfClothing.Key == wantedClothing[1])
                    {
                        Console.WriteLine($"* {pieceOfClothing.Key} - {pieceOfClothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pieceOfClothing.Key} - {pieceOfClothing.Value}");
                    }
                }
            }
        }
    }
}
