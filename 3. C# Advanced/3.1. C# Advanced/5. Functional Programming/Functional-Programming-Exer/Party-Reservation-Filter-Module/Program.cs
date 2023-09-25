using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, HashSet<string>> filters = new Dictionary<string, HashSet<string>>();
            filters.Add("Starts with", new HashSet<string>());
            filters.Add("Ends with", new HashSet<string>());
            filters.Add("Length", new HashSet<string>());
            filters.Add("Contains", new HashSet<string>());
            string command = "";
            while ((command = Console.ReadLine()) != "Print")
            {
                //"Add filter" / "Remove filter" / "Print"
                //"Starts with" / "Ends with" / "Length" / "Contains"
                //E.g.: "Add filter;Starts with;P"
                string[] commandArgs = command
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] == "Add filter")
                {
                    filters[commandArgs[1]].Add(commandArgs[2]);
                }
                else if (commandArgs[0] == "Remove filter")
                {
                    filters[commandArgs[1]].Remove(commandArgs[2]);
                }
            }

            for (int i = 0; i < guests.Count; i++)
            {
                bool isNameRemoved = false;
                foreach (var condition in filters)
                {
                    Func<string, string, bool> filter = CreateFilter(condition.Key);
                    foreach (string part in condition.Value)
                    {
                        if (filter(guests[i], part))
                        {
                            guests.RemoveAt(i);
                            i--;
                            isNameRemoved = true;
                            break;
                        }
                    }

                    if (isNameRemoved )
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', guests));
        }

        static Func<string, string, bool> CreateFilter(string condition)
        {
            switch (condition)
            {
                case "Starts with":
                    return (name, part) => name.StartsWith(part);
                case "Ends with":
                    return (name, part) => name.EndsWith(part);
                case "Length":
                    return (name, length) => name.Length == int.Parse(length);
                case "Contains":
                    return (name, part) => name.Contains(part);
                default:
                    return null;
            }
        }
    }
}
