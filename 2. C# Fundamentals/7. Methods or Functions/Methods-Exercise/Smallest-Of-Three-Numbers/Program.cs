using System;

namespace Smallest_Of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int leastNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < 2; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leastNumber = FindSmallerNumber(leastNumber, number);
            }
            Console.WriteLine(leastNumber);
        }
        static int FindSmallerNumber(int firstNumber, int secondNumber)
        {
            if (firstNumber < secondNumber)
            {
                return firstNumber;
            }
            return secondNumber;
        }
    }
}
