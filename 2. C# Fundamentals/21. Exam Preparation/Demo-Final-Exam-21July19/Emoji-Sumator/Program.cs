using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ');
            //"number:number:number:(…)"
            string specialEmoji = string
                .Join("", Console.ReadLine().Split(':').Select(x => (char)int.Parse(x)));
            List<string> validEmojis = words
                .Where(x => Regex.Match(x, @"^:[a-z]{4,}:[,.!?]?$").Success)
                .Select(x => x.Trim(':', ',', '?', '!', '.'))
                .ToList();
            int emojisPower = validEmojis
                .Select(x => x.ToCharArray().Sum(y => y))
                .Sum();
            emojisPower = validEmojis.Contains(specialEmoji) ? emojisPower * 2 : emojisPower;
            if (validEmojis.Any())
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", validEmojis.Select(x => $":{x}:"))}");
            }
            Console.WriteLine($"Total Emoji Power: {emojisPower}");
        }
    }
}
