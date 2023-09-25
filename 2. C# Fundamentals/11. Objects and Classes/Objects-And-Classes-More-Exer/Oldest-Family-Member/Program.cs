using System;

namespace Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < membersCount; i++)
            {
                //"{name} {age}"
                string[] memberData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person member = new Person(memberData[0], int.Parse(memberData[1]));
                family.AddMember(member);
            }
            Console.WriteLine(family.GetOldestMember());
        }
    }
}
