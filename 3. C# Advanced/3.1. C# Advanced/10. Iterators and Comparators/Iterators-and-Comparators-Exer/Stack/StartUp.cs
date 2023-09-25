using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = "";
            Stack<string> stack = new Stack<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    command = command.Replace("Push ", "");
                    string[] items = command
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                    stack.Push(items);
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }

            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
