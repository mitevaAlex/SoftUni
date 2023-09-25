using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();
                if (command.Contains("1"))
                {
                    int[] commandArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    nums.Push(commandArgs[1]);
                }
                else if (command == "2" && nums.Count > 0)
                {
                    nums.Pop();
                }
                else if (command == "3" && nums.Count > 0)
                {
                    Console.WriteLine(nums.Max());
                }
                else if (command == "4" && nums.Count > 0)
                {
                    Console.WriteLine(nums.Min());
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
