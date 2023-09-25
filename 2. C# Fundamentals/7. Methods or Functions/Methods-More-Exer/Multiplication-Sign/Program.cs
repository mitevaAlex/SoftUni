using System;

namespace Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            bool isProductZero = false;
            for (int i = 0; i < 3; i++)
            {
                isProductZero = IsProductZero(numbers[i]);
                if (isProductZero)
                {
                    Console.WriteLine("zero");
                    return;
                }
            }

            bool isFirstNumPositive = IsNumberPositive(numbers[0]);
            bool isSecondNumPositive = IsNumberPositive(numbers[1]);
            bool isThirdNumPositive = IsNumberPositive(numbers[2]);
            bool isProductPositive = IsProductPositive(isFirstNumPositive,
                isSecondNumPositive, isThirdNumPositive);
            if (isProductPositive)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }

        static bool IsProductZero(int number)
        {
            if (number == 0)
            {
                return true;
            }
            return false;
        }

        static bool IsNumberPositive(int number)
        {
            if (number > 0)
            {
                return true;
            }
            return false;
        }

        static bool IsProductPositive(bool isFirstNumPositive,
            bool isSecondNumPositive, bool isThirdNumPositive)
        {
            if (isFirstNumPositive)
            {
                if (isSecondNumPositive && isThirdNumPositive)
                {
                    return true;
                }
                else if (isSecondNumPositive || isThirdNumPositive)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (isSecondNumPositive && isThirdNumPositive)
                {
                    return false;
                }
                else if (isSecondNumPositive || isThirdNumPositive)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
