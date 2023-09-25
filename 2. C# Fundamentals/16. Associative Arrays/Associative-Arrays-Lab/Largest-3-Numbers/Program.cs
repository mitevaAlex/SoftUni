using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(' ', Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .OrderByDescending(x => x)
                 .Take(3)));
        }
    }
}
