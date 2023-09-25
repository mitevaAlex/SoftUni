using System;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //"Switch {index}" or "Change {index} {value}" or 
            //"Sum Negative" or "Sum Positive" or "Sum All"
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splittedCommand = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = splittedCommand[0];
                switch (operation)
                {
                    case "Switch":
                        int index = int.Parse(splittedCommand[1]);
                        if (IsIndexValid(numbers.Length, index))
                        {
                            numbers[index] *= -1; 
                        }
                        break;
                    case "Change":
                        index = int.Parse(splittedCommand[1]);
                        if (IsIndexValid(numbers.Length, index))
                        {
                            int newNumber = int.Parse(splittedCommand[2]);
                            numbers[index] = newNumber;
                        }
                        break;
                    case "Sum":
                        string typeNumbers = splittedCommand[1];
                        int sum = 0;
                        if (typeNumbers == "Negative")
                        {
                            sum = numbers
                                .Where(x => x < 0)
                                .Sum();
                        }
                        else if (typeNumbers == "Positive")
                        {
                            sum = numbers
                                .Where(x => x >= 0)
                                .Sum();
                        }
                        else if (typeNumbers == "All")
                        {
                            sum = numbers.Sum();
                        }
                        Console.WriteLine(sum);
                        break;
                }

            }
            int[] positiveNumbers = numbers
                .Where(x => x >= 0)
                .ToArray();
            Console.WriteLine(string.Join(' ', positiveNumbers));

        }

        static bool IsIndexValid(int numbersLength, int index)
        {
            if (index >= 0 && index < numbersLength)
            {
                return true;
            }
            return false;
        }
    }
}
