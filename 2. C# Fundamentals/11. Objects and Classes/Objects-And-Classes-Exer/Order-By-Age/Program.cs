using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                //"{name} {ID} {age}"
                string[] personData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personData[0], personData[1], int.Parse(personData[2])));
            }
            people = people
                .OrderBy(x => x.Age)
                .ToList();
            people.ForEach(x => Console.WriteLine(x));
        }
    }
}
