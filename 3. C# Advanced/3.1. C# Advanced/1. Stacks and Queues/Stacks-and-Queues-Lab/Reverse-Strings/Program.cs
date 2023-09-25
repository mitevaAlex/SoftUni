using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> inputChars = new Stack<char>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                inputChars.Push(input[i]);
            }

            while (inputChars.Count > 0)
            {
                Console.Write(inputChars.Pop());
            }

            Console.WriteLine();
        }
    }
}
