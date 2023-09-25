using System;
using System.Linq;

namespace Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());
            for (int currentNumber = 17; currentNumber <= lastNumber; currentNumber++)
            {
                int[] currentDigits = new int[currentNumber.ToString().Length];
                for (int i = 0; i < currentDigits.Length; i++)
                {
                    currentDigits[i] = currentNumber.ToString()[i] - '0';
                }

                bool isSumDivisibleBy8 = FindIfSumDivisibleByEight(currentDigits);
                bool hasAnOddDigit = FindIfHasAtLeastOneOddDigit(currentDigits);
                if (isSumDivisibleBy8 && hasAnOddDigit)
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }

        static bool FindIfSumDivisibleByEight(int[] currentDigits)
        {
            int digitsSum = currentDigits.Sum();
            if (digitsSum % 8 == 0)
            {
                return true;
            }
            return false;
        }

        static bool FindIfHasAtLeastOneOddDigit(int[] currentDigits)
        {
            for (int i = 0; i < currentDigits.Length; i++)
            {
                if (currentDigits[i] % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
