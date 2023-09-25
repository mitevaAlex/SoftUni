using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArrNumbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();
            int[] secondArrNumbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();

            for (int i = 0; i < firstArrNumbers.Length; i++)
            {
                int firstArrNum = firstArrNumbers[i];
                int secondArrNum = secondArrNumbers[i];
                if (firstArrNum != secondArrNum)
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            int sum = firstArrNumbers.Sum();
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
