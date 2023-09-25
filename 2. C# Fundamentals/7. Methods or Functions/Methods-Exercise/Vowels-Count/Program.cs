using System;
using System.Linq;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int vowelsCount = FindVowelsCount(word);
            Console.WriteLine(vowelsCount);
        }
        static int FindVowelsCount(string word)
        {
            int vowelsCount = 0;
            string vowels = "oaieu";
            for (int i = 0; i < word.Length; i++)
            {
                string currentLetter = word[i].ToString();
                if (vowels.Contains(currentLetter))
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
