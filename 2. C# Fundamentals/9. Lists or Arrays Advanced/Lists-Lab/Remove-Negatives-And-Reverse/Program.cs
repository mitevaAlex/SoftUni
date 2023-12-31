﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Negatives_And_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers.RemoveAll(x => x < 0);
            if (numbers.Count > 0)
            {
                numbers.Reverse();
                Console.WriteLine(string.Join(' ', numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
