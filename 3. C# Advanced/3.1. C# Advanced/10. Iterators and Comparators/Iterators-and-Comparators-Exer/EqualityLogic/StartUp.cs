using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedpeople = new SortedSet<Person>();
            HashSet<Person> people = new HashSet<Person>();
            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personArgs[0], int.Parse(personArgs[1]));
                sortedpeople.Add(person);
                people.Add(person);
            }

            Console.WriteLine(sortedpeople.Count);
            Console.WriteLine(people.Count);
        }
    }
}
