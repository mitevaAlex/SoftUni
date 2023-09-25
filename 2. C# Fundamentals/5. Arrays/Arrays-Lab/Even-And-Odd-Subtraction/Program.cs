using System;
using System.Linq;

namespace Even_And_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int evenNumbersSum = 0;
            int oddNumbersSum = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == 0)
                {
                    evenNumbersSum += currentNumber;
                }
                else
                {
                    oddNumbersSum += currentNumber;
                }
            }
            int difference = evenNumbersSum - oddNumbersSum;//the difference between the even and the odd sum
            Console.WriteLine(difference);
        }
    }
}
