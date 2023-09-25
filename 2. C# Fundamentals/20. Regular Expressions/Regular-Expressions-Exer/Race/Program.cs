using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = Console.ReadLine()
                .Split(", ")
                .ToDictionary(x => x, x => 0);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of race")
            {
                MatchCollection commandValidSymbols = Regex.Matches(command, @"(\d|[A-Za-z])");
                string currentRacer = string.Empty;
                int currentKilometers = 0;
                foreach (Match symbol in commandValidSymbols)
                {
                    bool isDigit = Regex.IsMatch(symbol.ToString(), @"\d");
                    if (isDigit)
                    {
                        currentKilometers += char.Parse(symbol.Value) - '0';
                    }
                    else
                    {
                        currentRacer += symbol.Value;
                    }
                }

                if (racers.ContainsKey(currentRacer))
                {
                    racers[currentRacer] += currentKilometers;
                }
            }
            racers = racers
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(x => x.Key, x => x.Value);
            List<string> winners = new List<string>();
            foreach (var winner in racers)
            {
                winners.Add(winner.Key);
            }

            Console.WriteLine($"1st place: {winners[0]}{Environment.NewLine}" +
                $"2nd place: {winners[1]}{Environment.NewLine}" +
                $"3rd place: {winners[2]}");
        }
    }
}
