using System;
using System.Collections.Generic;
using System.Linq;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string longString = strings[0].Length > strings[1].Length ? strings[0] : strings[1];
            string shortString = strings[0].Length > strings[1].Length ? strings[1] : strings[0];
            int sum = 0;
            for (int i = 0; i < shortString.Length; i++)
            {
                sum += longString[i] * shortString[i];
            }
            for (int i = shortString.Length; i < longString.Length; i++)
            {
                sum += longString[i];
            }
            Console.WriteLine(sum);
        }
    }
}
