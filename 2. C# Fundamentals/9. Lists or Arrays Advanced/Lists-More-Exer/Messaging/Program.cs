using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> codesOfNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string text = Console.ReadLine();
            string secretMessage = string.Empty;
            for (int i = 0; i < codesOfNumbers.Count; i++)
            {
                int currentCode = codesOfNumbers[i];
                int currentSum = 0;//the index from the text
                while (currentCode > 0)
                {
                    int currentDigit = currentCode % 10;
                    currentSum += currentDigit;
                    currentCode /= 10;
                }
                int textIndex = currentSum;
                if (currentSum > text.Length)
                {
                    textIndex = currentSum % text.Length;
                }
                secretMessage += text[textIndex];
                text = text.Remove(textIndex , 1);
            }
            Console.WriteLine(secretMessage);
        }
    }
}
