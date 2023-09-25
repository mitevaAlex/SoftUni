using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            //"Add {number}" or "Remove {number}" or "RemoveAt {index}" or "Insert {number} {index}"
            List<string> command = new List<string>();
            while (!(command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()).Contains("end"))
            {
                string operation = command[0];
                switch (operation)
                {
                    case "Add":
                        int number = int.Parse(command[1]);
                        numbers.Add(number);
                        break;
                    case "Remove":
                        number = int.Parse(command[1]);
                        numbers.Remove(number);
                        break;
                    case "RemoveAt":
                        int index = int.Parse(command[1]);
                        numbers.RemoveAt(index);
                        break;
                    case "Insert":
                        number = int.Parse(command[1]);
                        index = int.Parse(command[2]);
                        numbers.Insert(index, number);
                        break;
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
