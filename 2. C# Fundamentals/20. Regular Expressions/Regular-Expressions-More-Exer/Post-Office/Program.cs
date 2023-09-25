using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            //e.g.: "sdsGGasAOTPWEEEdas$AOTP$|a65:1.2s65:03d79:01ds84:02! -80:07++ABs90:1.1|adsaArmyd Gara So La Arm Armyw21 Argo O daOfa Or Ti Sar saTheww The Parahaos"
            string[] inputParts = Console.ReadLine()
                .Split('|');
            char[] capitalLetters = Regex
                .Match(inputParts[0], @"([#$*%&])[A-Z]+\1")
                .Value
                .Trim('#', '$', '*', '%', '&')
                .ToCharArray();
            List<Match> capitalLettersArgs = Regex
                .Matches(inputParts[1], @"[6789]\d:\d{2}")
                .ToList();
            for (int i = 0; i < capitalLettersArgs.Count; i++)
            {
                if (capitalLettersArgs
                    .Where(x => x.Value == capitalLettersArgs[i].Value)
                    .Count() > 1)
                {
                    capitalLettersArgs.Remove(capitalLettersArgs[i]);
                }
            }
            //stores capital letters and the count of letters (without the first letter) of the word starting with that letter
            Dictionary<char, int> validWordsArgs = capitalLettersArgs
                .Select(x => x.Value.Split(':'))
                .ToDictionary(x => (char)int.Parse(x[0]), x => int.Parse(x[1]));
            string[] words = inputParts[2]
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            foreach (char capitalLetter in capitalLetters)
            {
                int lettersCount = validWordsArgs[capitalLetter];
                foreach (string word in words)
                {
                    Match validWord = Regex.Match(word, $@"^{capitalLetter}.{{{lettersCount}}}$");
                    if (validWord.Success)
                    {
                        Console.WriteLine(validWord);
                    }
                }
            }
        }
    }
}
