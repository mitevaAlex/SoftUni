using System;
using System.Collections.Generic;
using System.Linq;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine()
                 .Split(", ")
                 .ToList();
            for (int i = 0; i < usernames.Count; i++)
            {
                string currentUsername = usernames[i];
                if (currentUsername.Length < 3 || currentUsername.Length > 16)
                {
                    usernames.Remove(currentUsername);
                    i--;
                    continue;
                }
                for (int j = 0; j < currentUsername.Length; j++)
                {
                    char currentChar = currentUsername[j];
                    if (!char.IsLetterOrDigit(currentChar) && currentChar != '-' && currentChar != '_')
                    {
                        usernames.Remove(currentUsername);
                        i--;
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
