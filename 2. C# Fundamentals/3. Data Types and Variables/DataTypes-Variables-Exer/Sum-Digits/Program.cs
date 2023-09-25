using System;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());//we are going to sum the digits of that number
            int digitsSum = 0;
            while (number !=0)
            {
                int currentDigit = number % 10;
                digitsSum += currentDigit;
                number /= 10;
            }
            Console.WriteLine(digitsSum);
        }
    }
}
