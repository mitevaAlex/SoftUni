using System;

namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                //"Translate {char} {replacement}" or  "Includes {string}" or 
                //"Start {string}" or "Lowercase" or "FindIndex {char}" or 
                //"Remove {startIndex} {count}"
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0];
                if (operation == "Translate")
                {
                    char oldChar = char.Parse(commandArgs[1]);
                    char newChar = char.Parse(commandArgs[2]);
                    text = text.Replace(oldChar, newChar);
                    Console.WriteLine(text);
                }
                else if (operation == "Includes")
                {
                    string stringToFind = commandArgs[1];
                    bool doesStringExist = text.Contains(stringToFind);
                    Console.WriteLine(doesStringExist);
                }
                else if (operation == "Start")
                {
                    string stringToFind = commandArgs[1];
                    bool doesStartWithString = text.StartsWith(stringToFind);
                    Console.WriteLine(doesStartWithString);
                }
                else if (operation == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (operation == "FindIndex")
                {
                    char charToFind = char.Parse(commandArgs[1]);
                    int lastIndexOfChar = text.LastIndexOf(charToFind);
                    Console.WriteLine(lastIndexOfChar);
                }
                else if (operation == "Remove")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int symbolsToRemoveCount = int.Parse(commandArgs[2]);
                    text = text.Remove(startIndex, symbolsToRemoveCount);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
