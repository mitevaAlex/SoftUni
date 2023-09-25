using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            List<string> command = new List<string>();//"{name} is going!" or "{name} is not going!"
            List<string> guestsNames = new List<string>();
            
            for (int i = 0; i < commandsCount; i++)
            {
                command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string currentName = command[0];
                if (command.Count == 4)
                {
                    if (guestsNames.Contains(currentName))
                    {
                        guestsNames.Remove(currentName);
                    }
                    else
                    {
                        Console.WriteLine($"{currentName} is not in the list!");
                    }
                }
                else
                {
                    if (guestsNames.Contains(currentName))
                    {
                        Console.WriteLine($"{currentName} is already in the list!");
                    }
                    else
                    {
                        guestsNames.Add(currentName);
                    }
                }
            }

            for (int i = 0; i < guestsNames.Count; i++)
            {
                Console.WriteLine(guestsNames[i]);
            }
        }
    }
}
