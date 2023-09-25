using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Chars_In_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> eachCharCount = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (letter == ' ')
                {
                    continue;
                }
                if (!eachCharCount.ContainsKey(letter))
                {
                    eachCharCount.Add(letter, 0);
                }
                eachCharCount[letter]++;
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                eachCharCount.Select(x => $"{x.Key} -> {x.Value}")));
        }
    }
}
