using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string middleChars = FindMiddleCharacters(word);
            Console.WriteLine(middleChars);
        }

        static string FindMiddleCharacters(string word)
        {
            string middleChars = string.Empty;
            if (word.Length % 2 == 0)
            {
                middleChars += word[word.Length / 2 - 1].ToString() + word[word.Length / 2].ToString();
            }
            else
            {
                middleChars += word[word.Length / 2];
            }
            return middleChars;
        }
    }
}
