using System;
using System.Linq;

namespace Fold_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();//length = 4 * k integers
            int kIntegers = numbers.Length / 4;
            int[] firstRow = new int[2 * kIntegers];
            int[] secondRow = new int[firstRow.Length];
            int counter = 0;
            for (int i = kIntegers - 1; i >= 0; i--)
            {
                firstRow[counter] = numbers[i];
                counter++;
            }

            for (int i = numbers.Length - 1; i >= numbers.Length - kIntegers; i--)
            {
                firstRow[counter] = numbers[i];
                counter++;
            }

            for (int i = 0; i < secondRow.Length; i++)
            {
                secondRow[i] = numbers[i + kIntegers];
            }
            int[] sum = new int[kIntegers * 2];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = firstRow[i] + secondRow[i];
            }
            string sumAsString = string.Join(' ', sum);
            Console.WriteLine(sumAsString);
        }
    }
}
