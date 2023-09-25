using System;
using System.Numerics;

namespace Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            int currentMultiplier = 2;
            while (currentMultiplier <= number)
            {
                factorial *= currentMultiplier;
                currentMultiplier++;
            }
            Console.WriteLine(factorial);
        }
    }
}
