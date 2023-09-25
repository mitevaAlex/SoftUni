using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < peopleCount; i++)
            {
                string[] memberInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person member = new Person(memberInfo[0], int.Parse(memberInfo[1]));
                family.AddMember(member);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember);
        }
    }
}
