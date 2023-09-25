using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodictable = new SortedSet<string>();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string element in elements)
                {
                    periodictable.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', periodictable));
        }
    }
}
