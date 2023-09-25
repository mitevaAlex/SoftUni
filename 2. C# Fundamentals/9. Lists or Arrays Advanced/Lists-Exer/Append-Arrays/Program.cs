using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersArrays = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();//e.g   1 2 3 |4 5 6 |  7  8
            List<int> finalNumbers = new List<int>();
            for (int i = numbersArrays.Count - 1; i >= 0; i--)
            {
                int[] currentNumbers = numbersArrays[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                finalNumbers.AddRange(currentNumbers);
            }
            Console.WriteLine(string.Join(' ', finalNumbers));
        }
    }
}
