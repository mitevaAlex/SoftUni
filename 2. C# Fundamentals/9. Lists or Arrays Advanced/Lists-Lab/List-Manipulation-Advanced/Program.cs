using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            //"Contains {number}" or "PrintEven" or "PrintOdd" or "GetSum" or "Filter {condition} {number}"
            List<string> command = new List<string>();
            bool areNumbersChanged = false;
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
                        areNumbersChanged = true;
                        break;
                    case "Remove":
                        number = int.Parse(command[1]);
                        numbers.Remove(number);
                        areNumbersChanged = true;
                        break;
                    case "RemoveAt":
                        int index = int.Parse(command[1]);
                        numbers.RemoveAt(index);
                        areNumbersChanged = true;
                        break;
                    case "Insert":
                        number = int.Parse(command[1]);
                        index = int.Parse(command[2]);
                        numbers.Insert(index, number);
                        areNumbersChanged = true;
                        break;
                    case "Contains":
                        number = int.Parse(command[1]);
                        if (numbers.Contains(number))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        List<int> evenNumbers = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            int currentNumber = numbers[i];
                            if (currentNumber % 2 == 0)
                            {
                                evenNumbers.Add(currentNumber);
                            }
                        }
                        Console.WriteLine(string.Join(' ', evenNumbers));
                        break;
                    case "PrintOdd":
                        List<int> oddNumbers = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            int currentNumber = numbers[i];
                            if (currentNumber % 2 != 0)
                            {
                                oddNumbers.Add(currentNumber);
                            }
                        }
                        Console.WriteLine(string.Join(' ', oddNumbers));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        string condition = command[1];
                        int compareNumber = int.Parse(command[2]);
                        List<int> filteredNumbers = new List<int>();
                        switch (condition)
                        {
                            case "<":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int currentNumber = numbers[i];
                                    if (currentNumber < compareNumber)
                                    {
                                        filteredNumbers.Add(currentNumber);
                                    }
                                }
                                break;
                            case ">":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int currentNumber = numbers[i];
                                    if (currentNumber > compareNumber)
                                    {
                                        filteredNumbers.Add(currentNumber);
                                    }
                                }
                                break;
                            case "<=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int currentNumber = numbers[i];
                                    if (currentNumber <= compareNumber)
                                    {
                                        filteredNumbers.Add(currentNumber);
                                    }
                                }
                                break;
                            case ">=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int currentNumber = numbers[i];
                                    if (currentNumber >= compareNumber)
                                    {
                                        filteredNumbers.Add(currentNumber);
                                    }
                                }
                                break;
                        }
                        Console.WriteLine(string.Join(' ', filteredNumbers));
                        break;
                }
            }
            if (areNumbersChanged)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
