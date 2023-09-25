using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int elementsToDequeue = commands[1];
            int wantedElement = commands[2];
            Queue<int> queueNums = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            for (int i = 0; i < elementsToDequeue; i++)
            {
                queueNums.Dequeue();
            }

            Console.WriteLine(queueNums.Contains(wantedElement) ? "true" : queueNums.Count > 0 ? queueNums.Min().ToString() : "0");
        }
    }
}
