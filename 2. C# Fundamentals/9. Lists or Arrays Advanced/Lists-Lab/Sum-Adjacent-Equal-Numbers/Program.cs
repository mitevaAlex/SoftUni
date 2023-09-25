using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            for (int i = 1; i < numbers.Count; i++)
            {
                double currentNumber = numbers[i];
                double previousNumber = numbers[i - 1];
                if (previousNumber == currentNumber)
                {
                    numbers[i - 1] += currentNumber;
                    numbers.RemoveAt(i);
                    i -= 2;
                    if (i < 0)
                    {
                        i = 0;
                    }
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
