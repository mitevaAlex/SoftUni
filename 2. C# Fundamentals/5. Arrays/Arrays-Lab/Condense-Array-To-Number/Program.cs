using System;
using System.Linq;

namespace Condense_Array_To_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();
            int result = 0;
            while (numbers.Length > 1)
            {                            
                int[] condensedNums = new int[numbers.Length - 1];
                for (int j = 0; j < condensedNums.Length; j++)
                {
                    int currentNum = numbers[j];
                    int nextNum = numbers[j + 1];
                    condensedNums[j] = currentNum + nextNum;
                }
                numbers = condensedNums;
            }
            result = numbers[0];
            Console.WriteLine(result);
        }
    }
}
