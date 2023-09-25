using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                //"{forceSide} | {forceUser}" or "{forceUser} -> {forceSide}"
                List<string> forceSideData = new List<string>();
                if (command.Contains('|'))
                {
                    forceSideData = command
                        .Split(" | ")
                        .ToList();
                    string forceSide = forceSideData[0];
                    string forceUser = forceSideData[1];       
                    bool doesUserExist = false;
                    foreach (var forceUsers in forceSides)
                    {
                        if (forceUsers.Value.Contains(forceUser))
                        {
                            doesUserExist = true;
                            break;
                        }
                    }

                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides.Add(forceSide, new List<string>());
                    }

                    if (!doesUserExist)
                    {
                        forceSides[forceSide].Add(forceUser);
                    }

                }
                else if (command.Contains("->"))
                {
                    forceSideData = command
                        .Split(" -> ")
                        .ToList();
                    string forceSide = forceSideData[1];
                    string forceUser = forceSideData[0];
                    foreach (var forceUsers in forceSides)
                    {
                        if (forceUsers.Value.Contains(forceUser))
                        {
                            forceUsers.Value.Remove(forceUser);
                            break;
                        }
                    }

                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides.Add(forceSide, new List<string>());
                    }

                    forceSides[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            forceSides = forceSides
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x=> x.Value);
            foreach (var forceUsers in forceSides)
            {
                forceUsers.Value.Sort();
            }

            Console.WriteLine(string.Join(Environment.NewLine,
                forceSides.Select(x => $"Side: {x.Key}, Members: {x.Value.Count}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, x.Value.Select(y => $"! {y}"))}")));
        }
    }
}
