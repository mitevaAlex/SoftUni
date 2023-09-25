using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            //"Add {number}" or "Insert {number} {index}" or "Remove {index}" or "Shift left {count}" or "Shift right {count}"
            List<string> command = new List<string>();

            while (!(command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()).Contains("End"))
            {
                string operation = command[0];
                switch (operation)
                {
                    case "Add":
                        int number = int.Parse(command[1]);
                        numbers.Add(number);
                        break;
                    case "Insert":
                        int index = int.Parse(command[2]);
                        bool isIndexValid = IsIndexValid(numbers, index);
                        if (isIndexValid)
                        {
                            number = int.Parse(command[1]);
                            numbers.Insert(index, number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        index = int.Parse(command[1]);
                        isIndexValid = IsIndexValid(numbers, index);
                        if (isIndexValid)
                        {
                            numbers.RemoveAt(index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        string direction = command[1];
                        int count = int.Parse(command[2]);
                        if (direction == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }

        static bool IsIndexValid(List<int> numbers, int index)
        {
            if (index < numbers.Count && index >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
