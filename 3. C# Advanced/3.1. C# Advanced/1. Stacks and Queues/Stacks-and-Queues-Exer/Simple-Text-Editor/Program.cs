using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            int commandsCount = int.Parse(Console.ReadLine());
            Stack<string> textLastVersions = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (commandArgs[0])
                {
                    case "1":
                        textLastVersions.Push(builder.ToString());
                        builder.Append(commandArgs[1]);
                        break;
                    case "2":
                        textLastVersions.Push(builder.ToString());
                        int countToRemove = int.Parse(commandArgs[1]);
                        builder.Remove(builder.Length - countToRemove, countToRemove);
                        break;
                    case "3":
                        int wantedIndex = int.Parse(commandArgs[1]) - 1;
                        Console.WriteLine(builder[wantedIndex]);
                        break;
                    case "4":
                        builder = new StringBuilder();
                        builder.Append(textLastVersions.Pop());
                        break;
                }
            }
        }
    }
}
