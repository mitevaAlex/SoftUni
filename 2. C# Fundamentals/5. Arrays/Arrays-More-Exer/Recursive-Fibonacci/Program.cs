using System;

namespace Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedFibonacciNumber = int.Parse(Console.ReadLine());//the sequent number
            long wantedNumber = 1;
            if (wantedFibonacciNumber == 1 || wantedFibonacciNumber == 2)
            {
                Console.WriteLine(wantedNumber);                
            }
            else
            {
                wantedNumber = FindFibonacciNumber(wantedFibonacciNumber);
                Console.WriteLine(wantedNumber);
            }
        }

        static long FindFibonacciNumber(int wantedFibonacciNumber)
        {
            long firstNumber = 1;
            long secondNumber = 1;
            long wantedNumber = 0;
            for (int i = 3; i <= wantedFibonacciNumber; i++)
            {
                wantedNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = wantedNumber;
            }

            return wantedNumber;
        }
    }
}
