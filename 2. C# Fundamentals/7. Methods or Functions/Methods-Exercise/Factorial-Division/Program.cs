using System;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            long firstFactorial = FindFactorial(firstNumber);
            long secondFactorial = FindFactorial(secondNumber);
            double factorialDivision = (double)firstFactorial / secondFactorial ;
            Console.WriteLine($"{factorialDivision:f2}");
        }

        static long FindFactorial(int number)
        {
            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
