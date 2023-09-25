using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueUsernames = new HashSet<string>();
            int usernamesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < usernamesCount; i++)
            {
                uniqueUsernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, uniqueUsernames));
        }
    }
}
