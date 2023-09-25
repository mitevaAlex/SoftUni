using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personInfo[0], int.Parse(personInfo[1]));
                people.Add(person);
            }

            Predicate<Person> over30Check = person => person.Age > 30;
            people = people
                .Where(person => over30Check(person))
                .OrderBy(person => person.Name)
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}
