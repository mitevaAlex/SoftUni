using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> symbolCounts = new SortedDictionary<char, int>();
            foreach (char symbol in text)
            {
                if (!symbolCounts.ContainsKey(symbol))
                {
                    symbolCounts.Add(symbol, 0);
                }

                symbolCounts[symbol]++;
            }

            Console.WriteLine(string.Join(Environment.NewLine, symbolCounts.Select(x => $"{x.Key}: {x.Value} time/s")));
        }
    }
}
