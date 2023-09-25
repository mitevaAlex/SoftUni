using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] setSizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < setSizes[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setSizes[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            List<int> mutualNums = firstSet.Where(x => secondSet.Contains(x)).ToList();
            Console.WriteLine(string.Join(' ', mutualNums));
        }
    }
}
