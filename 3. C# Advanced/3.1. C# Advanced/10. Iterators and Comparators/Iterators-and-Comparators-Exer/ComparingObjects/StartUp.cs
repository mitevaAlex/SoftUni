using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personArgs[0], int.Parse(personArgs[1]), personArgs[2]));
            }

            int wantedPersonIndex = int.Parse(Console.ReadLine()) - 1;
            Person wantedPerson = people[wantedPersonIndex];
            int equalPeopleCount = 0;
            int unequealPeopleCount = 0;
            foreach (Person person in people)
            {
                if (wantedPerson.CompareTo(person) == 0)
                {
                    equalPeopleCount++;
                }
                else
                {
                    unequealPeopleCount++;
                }
            }

            if (equalPeopleCount > 1)
            {
                Console.WriteLine($"{equalPeopleCount} {unequealPeopleCount} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
