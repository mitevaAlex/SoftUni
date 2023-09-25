using System;
using System.Linq;

namespace Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                 .Split(", ");
            string text = Console.ReadLine();
            foreach (string bannedWord in bannedWords)
            {
                while (text.Contains(bannedWord))
                {
                    text = text.Replace(bannedWord, new string('*', bannedWord.Length));
                }
            }
            Console.WriteLine(text);
        }
    }
}
