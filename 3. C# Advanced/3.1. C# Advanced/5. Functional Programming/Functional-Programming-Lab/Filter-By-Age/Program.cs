using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Dictionary<string, int> peopleAges = new Dictionary<string, int>();
            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                peopleAges.Add(personInfo[0], int.Parse(personInfo[1]));
            }

            string command = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            Predicate<int> filter = CreateFilter(command, ageFilter);
            peopleAges = peopleAges
                .Where(x => filter(x.Value))
                .ToDictionary(x => x.Key, x => x.Value);
            string printFormat = Console.ReadLine();
            Action<KeyValuePair<string, int>> printer = CreatePrinter(printFormat);
            foreach (var person in peopleAges)
            {
                printer(person);
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string printFormat)
        {
            switch (printFormat)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value); ;
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    return null;
            }
        }

        static Predicate<int> CreateFilter(string command, int ageFilter)
        {
            switch (command)
            {
                case "younger":
                    return x => x < ageFilter;
                case "older":
                    return x => x >= ageFilter;
                default:
                    return null;

            }
        }
    }
}
