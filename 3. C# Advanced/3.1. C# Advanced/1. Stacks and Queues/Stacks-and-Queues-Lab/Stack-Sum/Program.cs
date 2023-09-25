using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            string command = "";
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] splittedCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (splittedCommand[0])
                {
                    case "add":
                        numbers.Push(int.Parse(splittedCommand[1]));
                        numbers.Push(int.Parse(splittedCommand[2]));
                        break;
                    case "remove":
                        int numbersToRemove = int.Parse(splittedCommand[1]);
                        if (numbersToRemove <= numbers.Count)
                        {
                            for (int i = 0; i < numbersToRemove; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;
                }
            }

            int numbersSum = numbers.Sum();
            Console.WriteLine($"Sum: {numbersSum}");
        }
    }
}
