using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0];
                if (operation == "Add")
                {
                    string newText = commandArgs[1];
                    result += newText;
                }
                else if (operation == "Upgrade")
                {
                    char symbolToUpgrade = char.Parse(commandArgs[1]);
                    result = result.Replace(symbolToUpgrade, (char)(symbolToUpgrade + 1));
                }
                else if (operation == "Print")
                {
                    Console.WriteLine(result);
                }
                else if (operation == "Index")
                {
                    char symbolToFind = char.Parse(commandArgs[1]);
                    List<int> indexes =result
                        .Select((x,i) => i)
                        .Where(i => result[i] == symbolToFind)
                        .ToList();
                    if (indexes.Any())
                        Console.WriteLine(string.Join(' ', indexes));
                    else
                        Console.WriteLine("None");
                }
                else if (operation == "Remove")
                {
                    string textToRemove = commandArgs[1];
                    while (result.Contains(textToRemove))
                    {
                        int indexToRemove = result.IndexOf(textToRemove);
                        result = result.Remove(indexToRemove, textToRemove.Length);
                    }
                }
            }
        }
    }
}
