using System;

namespace Multiply_Evens_By_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int sumEvenDigits = GetSumOfEvenDigits(number);
            int sumOddDigits = GetSumOfOddDigits(number);
            int production = GetMultipleOfEvensAndOdds(sumEvenDigits, sumOddDigits);
            Console.WriteLine(production);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int currentDigit = number % 10;
                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }
                number /= 10;
            }
            return sum;
        }
        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            while(number > 0)
            {
                int currentDigit = number % 10;
                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }
                number /= 10;
            }
            return sum;
        }

        static int GetMultipleOfEvensAndOdds(int sumEvenDigits, int sumOddDigits)
        {
            int result = sumEvenDigits * sumOddDigits;
            return result;
        }
    }
}
