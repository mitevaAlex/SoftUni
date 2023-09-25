using System;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordsOddOccurrencesCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                int currentWordCount = words.Count(x => x == word);
                if (!wordsOddOccurrencesCount.ContainsKey(word) && currentWordCount % 2 == 1)
                {
                    wordsOddOccurrencesCount[word] = currentWordCount;
                }
            }
            Console.WriteLine(string.Join(' ', wordsOddOccurrencesCount.Select(x => $"{x.Key}")));
        }
    }
}
