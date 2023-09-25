using System;
using System.Collections.Generic;
using System.Linq;

namespace Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            for (int i = 0; i < wordsCount; i++)
            {
                string keyWord = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!synonyms.ContainsKey(keyWord))
                {
                    synonyms.Add(keyWord, new List<string>());
                }
                synonyms[keyWord].Add(synonym);
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                synonyms.Select(x => $"{x.Key} - {string.Join(", ", x.Value)}")));
        }
    }
}
