using System;
using System.Linq;

namespace Max_Sequence_Of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int currentEqualElementsCount = 1;
            int mostEqualElementsCount = 1;
            int repetitiveNumber = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                int previousNumber = numbers[i - 1];
                int currentNumber = numbers[i];

                if (previousNumber == currentNumber)
                {
                    currentEqualElementsCount++;
                    if (currentEqualElementsCount > mostEqualElementsCount)
                    {
                        mostEqualElementsCount = currentEqualElementsCount;
                        repetitiveNumber = currentNumber;
                    }
                }
                else
                {
                    currentEqualElementsCount = 1;
                }
            }
            for (int i = 0; i < mostEqualElementsCount; i++)
            {
                Console.Write(repetitiveNumber + " ");
            }
        }
    }
}
