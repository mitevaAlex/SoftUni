using System;

namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            // e.g. : "aaaaabbbbbcdddeeeedssaa"
            string text = Console.ReadLine();
            for (int i = 1; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                char previousSymbol = text[i - 1];
                if (currentSymbol == previousSymbol)
                {
                    text = text.Remove(i - 1, 1);
                    i--;
                }
            }
            Console.WriteLine(text);
        }
    }
}
