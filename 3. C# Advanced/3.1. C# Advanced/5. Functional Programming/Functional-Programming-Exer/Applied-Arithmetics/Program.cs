using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<List<int>, List<int>> add = x => x.Select(y => y + 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(y => y * 2).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(y => y - 1).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(' ', x));
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = add(nums);
                        break;
                    case "multiply":
                        nums = multiply(nums);
                        break;
                    case "subtract":
                        nums = subtract(nums);
                        break;
                    case "print":
                        print(nums);
                        break;
                }
            }
        }
    }
}
