using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(SumElements(numbers, numbers.Length - 1));
        }

        static int SumElements(int[] numbers, int index)
        {
            if (index == 0)
            {
                return numbers[index];
            }

            return numbers[index] + SumElements(numbers, --index);
        }
    }
}
