using System;
using System.Linq;

namespace Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            PrintTribonachiSequence(numbersCount);
        }

        static void PrintTribonachiSequence(int numbersCount)
        {
            int[] numsForSum = new int[3];
            numsForSum[2] = 1;
            int[] tribonachiSequence = new int[numbersCount];
            tribonachiSequence[0] = 1;
            for (int i = 1; i < numbersCount; i++)
            {
                int currentNumber = numsForSum.Sum();
                for (int j = 0; j < numsForSum.Length - 1; j++)
                {
                    numsForSum[j] = numsForSum[j + 1];
                }
                numsForSum[numsForSum.Length - 1] = currentNumber;
                tribonachiSequence[i] = currentNumber;
            }
            string tribonachiSequenceAsString = string.Join(' ', tribonachiSequence);
            Console.WriteLine(tribonachiSequenceAsString);
        }
    }
}
