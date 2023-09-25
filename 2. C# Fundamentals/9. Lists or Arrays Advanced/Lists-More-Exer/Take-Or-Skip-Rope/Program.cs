using System;
using System.Collections.Generic;
using System.Linq;

namespace Take_Or_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialMessage = Console.ReadLine();
            List<int> numbers= new List<int>();
            List<string> nonNumbers = new List<string>();
            for (int i = 0; i < initialMessage.Length; i++)
            {
                char currentSymbol = initialMessage[i];
                if (char.IsDigit(currentSymbol))
                {
                    numbers.Add(currentSymbol - '0');
                }
                else
                {
                    nonNumbers.Add(currentSymbol.ToString());
                }
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            string secretString = string.Empty;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            int usedCharsCount = 0;
            for (int i = 0; i < takeList.Count; i++)//takeList.Count = skipList.Count
            {
                int currentTake = takeList[i];
                int currentSkip = skipList[i];
                for (int j = usedCharsCount; j < currentTake + usedCharsCount && j < nonNumbers.Count; j++)
                {
                    secretString += nonNumbers[j];
                }
                usedCharsCount += currentTake + currentSkip;
            }
            Console.WriteLine(secretString);
        }
    }
}
