using System;
using System.Linq;

namespace Reverse_Array_Of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');
           
            Console.WriteLine(string.Join(' ', input.Reverse()));
        }
    }
}
