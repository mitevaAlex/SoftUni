using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            SortedDictionary<int, int> numbersOccurrencesCount = new SortedDictionary<int, int>();
            foreach (int number in numbers)
            {
                if (!numbersOccurrencesCount.ContainsKey(number))
                {
                    numbersOccurrencesCount[number] = numbers.Count(x => x == number);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, 
                numbersOccurrencesCount.Select(x => $"{x.Key} -> {x.Value}")));
        }
    }
}
