using System;
using System.Collections.Generic;
using System.Linq;

namespace Mixed_Up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> secondNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int[] range = new int[2];
            if (firstNumbers.Count > secondNumbers.Count)
            {
                range[0] = firstNumbers[firstNumbers.Count - 1];
                range[1] = firstNumbers[firstNumbers.Count - 2];
                firstNumbers.RemoveRange(firstNumbers.Count - 2, 2);
            }
            else if (firstNumbers.Count < secondNumbers.Count)
            {
                range[0] = secondNumbers[0];
                range[1] = secondNumbers[1];
                secondNumbers.RemoveRange(0, 2);
            }
            Array.Sort(range);
            List<int> mixedList = new List<int>();
            for (int i = 0; i < firstNumbers.Count; i++)//firstNumbers.Count = secondNumbers.Count
            {
                mixedList.Add(firstNumbers[i]);
                mixedList.Add(secondNumbers[secondNumbers.Count - 1 - i]);
            }
            List<int> resultList = new List<int>();
            int leastNumberBorder = range[0];
            int greatestNumberBorder = range[1];
            for (int i = 0; i < mixedList.Count; i++)
            {
                int currentNumber = mixedList[i];
                if (currentNumber < greatestNumberBorder && currentNumber > leastNumberBorder)
                {
                    resultList.Add(currentNumber);
                }
            }
            resultList.Sort();
            Console.WriteLine(string.Join(' ', resultList));
        }
    }
}
