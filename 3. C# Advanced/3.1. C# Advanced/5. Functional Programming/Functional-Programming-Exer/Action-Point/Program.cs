using System;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printArray = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            printArray(words);
        }
    }
}
