using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = "";
            while ((command = Console.ReadLine()) != "Party!")
            {
                //"Double StartsWith Pesh" / "Double EndsWith esho" / "Remove Length 5"
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Func<string, string, bool> check = CreateCheck(commandArgs[1]);
                for (int i = 0; i < guests.Count; i++)
                {
                    if (check(guests[i], commandArgs[2]))
                    {
                        ModifyGuestList(guests[i], i, guests, commandArgs[0]);
                        switch (commandArgs[0])
                        {
                            case "Double":
                                i++;
                                break;
                            case "Remove":
                                i--;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            Console.WriteLine(guests.Count > 0 ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }

        static Func<string, string, bool> CreateCheck(string condition)
        {
            switch (condition)
            {
                case "StartsWith":
                    return (name, part) => name.StartsWith(part);
                case "EndsWith":
                    return (name, part) => name.EndsWith(part);
                case "Length":
                    return (name, length) => name.Length == int.Parse(length);
                default:
                    return null;
            }
        }

        static void ModifyGuestList(string name, int nameIndex, List<string> guests, string operation)
        {
            switch (operation)
            {
                case "Double":
                    guests.Insert(nameIndex + 1, name);
                    break;
                case "Remove":
                    guests.RemoveAt(nameIndex);
                    break;
                default:
                    break;
            }
        }
    }
}
