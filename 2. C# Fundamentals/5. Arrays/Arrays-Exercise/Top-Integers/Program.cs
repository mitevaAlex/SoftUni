using System;
using System.Linq;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int currentNumber = numbers[i];
                bool isTopInteger = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (currentNumber <= numbers[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    Console.Write(currentNumber + " ");
                }
            }
            Console.WriteLine(numbers[numbers.Length - 1]);
        }
    }
}
