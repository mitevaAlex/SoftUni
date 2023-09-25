using System;
using System.Collections.Generic;
using System.Linq;

namespace Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            if (numbers.Count % 2 == 0)
            {
                SumEnds(numbers);
            }
            else
            {
                int middleNumber = numbers[numbers.Count / 2];
                numbers.RemoveAt(numbers.Count / 2);
                SumEnds(numbers);
                numbers.Add(middleNumber);
            }
            Console.WriteLine(string.Join(' ', numbers));
        }

        static void SumEnds(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                numbers[i] += numbers[numbers.Count - 1 - i];
            }
            numbers.RemoveRange(numbers.Count / 2, numbers.Count / 2);
        }
    }
}
