using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int[] specialNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bombNumber = specialNumbers[0];
            int bombNumPower = specialNumbers[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];               
                if (currentNumber == bombNumber)
                {
                    int numbersRemoved = 0;
                    for (int j = i - bombNumPower; numbersRemoved < bombNumPower * 2 + 1; j++)
                    {
                        if (j < 0)
                        {
                            numbersRemoved++;
                            continue;                            
                        }
                        else if (j == numbers.Count)
                        {
                            break;
                        }
                        numbers[j] = 0;                        
                        numbersRemoved++;
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
