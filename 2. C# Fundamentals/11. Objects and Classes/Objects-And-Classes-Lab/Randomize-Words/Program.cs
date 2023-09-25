using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Random rand = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                int newIndex = rand.Next(0, words.Length);
                string randWord = words[newIndex];
                words[newIndex] = currentWord;
                words[i] = randWord;
            }
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
