using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            List<string> command = new List<string>();//"Delete {element} or "Insert {element} {position}"

            while (!(command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()).Contains("end"))
            {
                if (command.Count == 3)
                {
                    int element = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, element);
                }
                else
                {
                    int element = int.Parse(command[1]);
                    numbers.RemoveAll(x => x == element);
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
