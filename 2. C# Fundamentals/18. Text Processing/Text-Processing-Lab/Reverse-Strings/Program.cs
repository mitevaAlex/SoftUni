using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> reversedWords = new Dictionary<string, string>();
            string word = string.Empty;
            while ((word = Console.ReadLine()) != "end")
            {
                reversedWords[word] = string.Join("", word.Reverse());
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                reversedWords.Select(x => $"{x.Key} = {x.Value}")));
        }
    }
}
