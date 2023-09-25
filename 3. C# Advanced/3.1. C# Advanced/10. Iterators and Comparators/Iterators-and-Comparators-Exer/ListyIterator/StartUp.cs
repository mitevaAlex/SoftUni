using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = "";
            ListyIterator<string> listyIterator = null;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Create"))
                {
                    string[] items = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray();
                    listyIterator = new ListyIterator<string>(items);
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else if (command == "PrintAll")
                {
                    try
                    {
                        listyIterator.PrintAll();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }
        }
    }
}
