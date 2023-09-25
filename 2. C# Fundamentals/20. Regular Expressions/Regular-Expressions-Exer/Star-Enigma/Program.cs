using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            for (int i = 0; i < messagesCount; i++)
            {
                string message = Console.ReadLine();
                int starLettersCount = Regex.Matches(message, @"[starSTAR]").Count;
                message = string.Join("", message.Select(x => (char)(x - starLettersCount)));
                Match attackArgs = Regex.Match(message, @"@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<soldiersCount>\d+)[^@\-!:>]*");
                if (attackArgs.Success)
                {
                    string attackType = attackArgs.Groups["attackType"].Value;
                    string planetName = attackArgs.Groups["name"].Value;
                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }               
            }
            attackedPlanets.Sort();
            destroyedPlanets.Sort();
            string outputFormat = "-> {0}";
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}{Environment.NewLine}" +
                $"{string.Join("", attackedPlanets.Select(x => string.Format(outputFormat, x) + Environment.NewLine))}" +
                $"Destroyed planets: {destroyedPlanets.Count}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, destroyedPlanets.Select(x => string.Format(outputFormat, x)))}");
        }
    }
}
