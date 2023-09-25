using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Word_Count
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] words = await File.ReadAllLinesAsync("words.txt");
            string text = await File.ReadAllTextAsync("text.txt");
            foreach (string word in words)
            {
                MatchCollection matches = Regex.Matches(text, @$"(?i)\b{word}\b");
                wordsCount.Add(word, matches.Count);
            }

            await File.WriteAllLinesAsync("../../../actualResults.txt", wordsCount.Select(x => $"{x.Key} - {x.Value}"));
        }
    }
}
