using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Queue<string> names = new Queue<string>();
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(command);
                }
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
