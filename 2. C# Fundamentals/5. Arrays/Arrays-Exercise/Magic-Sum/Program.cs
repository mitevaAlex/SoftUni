using System;
using System.Linq;

namespace Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int magicSum = int.Parse(Console.ReadLine());//we want to find pairs of numbers 
            //from the array which have that sum
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNumber = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int secondNumber = numbers[j];
                    if (firstNumber + secondNumber == magicSum)
                    {
                        Console.WriteLine($"{firstNumber} {secondNumber}");
                    }
                }
            }
        }
    }
}
