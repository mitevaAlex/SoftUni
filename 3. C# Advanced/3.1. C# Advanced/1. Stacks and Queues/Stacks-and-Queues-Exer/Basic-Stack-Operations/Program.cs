using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int elementsToPop = commands[1];
            int wantedElement = commands[2];
            Stack<int> stackNums = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            for (int i = 0; i < elementsToPop; i++)
            {
                stackNums.Pop();
            }

            Console.WriteLine(stackNums.Contains(wantedElement) ? "true" : stackNums.Count > 0 ? stackNums.Min().ToString() : "0");


            //int[] commands = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //int stackCount = commands[0];
            //int elementsToPop = commands[1];
            //int wantedElement = commands[2];
            //int[] numbers = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //Stack<int> stackNums = new Stack<int>();
            //for (int i = 0; i < stackCount; i++)
            //{
            //    stackNums.Push(numbers[i]);
            //}

            //for (int i = 0; i < elementsToPop; i++)
            //{
            //    stackNums.Pop();
            //}

            //if (stackNums.Contains(wantedElement))
            //{
            //    Console.WriteLine("true");
            //}
            //else if (stackNums.Count > 0)
            //{
            //    Console.WriteLine(stackNums.Min());
            //}
            //else
            //{
            //    Console.WriteLine(0);
            //}
        }
    }
}
