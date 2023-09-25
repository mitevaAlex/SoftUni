using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> secondNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int longestCount = firstNumbers.Count;
            if (firstNumbers.Count < secondNumbers.Count)
            {
                longestCount = secondNumbers.Count;
            }
            List<int> mergedNumbers = new List<int>();
            for (int i = 0; i < longestCount; i++)
            {
                if (i < firstNumbers.Count)
                {
                    mergedNumbers.Add(firstNumbers[i]);
                }

                if (i < secondNumbers.Count)
                {
                    mergedNumbers.Add(secondNumbers[i]);
                }
            }
            Console.WriteLine(string.Join(' ', mergedNumbers));
        }
    }
}
