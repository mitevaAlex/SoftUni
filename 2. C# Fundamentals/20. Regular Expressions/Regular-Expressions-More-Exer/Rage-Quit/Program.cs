using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            //e.g: "aSd2&5s@1"
            string[] symbolsNumberPairs = Regex
                .Matches(Console.ReadLine(), @".+?\d+")
                .Select(x => x.Value.ToUpper())
                .ToArray();
            List<char> uniqueSymbols = new List<char>();
            StringBuilder text = new StringBuilder();
            foreach (string symbolsNumberPair in symbolsNumberPairs)
            {
                string textToRepeat = Regex.Match(symbolsNumberPair, @"\D+").Value;
                int repeatCount = int.Parse(Regex.Match(symbolsNumberPair, @"\d+").Value);
                for (int i = 0; i < repeatCount; i++)
                {
                    text.Append(textToRepeat);
                }

                if (repeatCount != 0)
                {
                    foreach (char symbol in textToRepeat)
                    {
                        if (!uniqueSymbols.Contains(symbol))
                        {
                            uniqueSymbols.Add(symbol);
                        }
                    }
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}{Environment.NewLine}" +
                $"{text}");
        }
    }
}
