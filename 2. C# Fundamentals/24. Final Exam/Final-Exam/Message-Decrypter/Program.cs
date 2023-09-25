using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesInputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesInputCount; i++)
            {
                string input = Console.ReadLine();
                Regex validMessagePattern = new Regex(@"^([$%])[A-Z][a-z]{2,}\1: \[\d+\]\|\[\d+\]\|\[\d+\]\|$");
                Match validMessage = validMessagePattern.Match(input);
                if (validMessage.Success)
                {
                    List<string> messageArgs = validMessage
                        .Value
                        .Split(new char[] { '$', '%', '|', ':', '[', ']' , ' '}, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    string decryptedMessage = messageArgs[0] + ": ";
                    messageArgs.RemoveAt(0);
                    foreach (string asciiCodeAsString in messageArgs)
                    {
                        char currentLetter = (char)int.Parse(asciiCodeAsString);
                        decryptedMessage += currentLetter;
                    }
                    Console.WriteLine(decryptedMessage);
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
