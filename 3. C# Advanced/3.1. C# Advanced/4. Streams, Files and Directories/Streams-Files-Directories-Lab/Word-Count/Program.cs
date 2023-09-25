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
            string[] words;
            using (StreamReader sr = new StreamReader("words.txt"))
            {
                string text = await sr.ReadToEndAsync();
               words = text
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            using (StreamReader sr = new StreamReader("text.txt"))
            {
                string text = await sr.ReadToEndAsync();
                foreach (string word in words)
                {
                    MatchCollection matches = Regex.Matches(text, @$"(?i)\b{word}\b");
                    wordsCount.Add(word, matches.Count);
                }
            }

            wordsCount = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            using (StreamWriter sw = new StreamWriter("Output.txt"))
            {
                foreach (var word in wordsCount)
                {
                    await sw.WriteLineAsync($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
