using System;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printPoliteness = x => Console.WriteLine($"Sir {x}");
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in names)
            {
                printPoliteness(name);
            }
        }
    }
}
