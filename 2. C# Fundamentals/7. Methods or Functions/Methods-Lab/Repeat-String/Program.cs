using System;

namespace Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int repetitionsCount = int.Parse(Console.ReadLine());
            string finalWord = RepeatWord(word, repetitionsCount);
            Console.WriteLine(finalWord);
        }

        static string RepeatWord(string word, int repetitionsCount)
        {
            string finalWord = string.Empty;
            for (int i = 0; i < repetitionsCount; i++)
            {
                finalWord += word;
            }
            return finalWord;
        }
    }
}
