using System;
using System.Linq;
using System.Collections.Generic;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int waterWasted = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int cupCapacity = cups.Peek();
                while (cupCapacity > 0)
                {
                    if (bottles.Peek() >= cupCapacity)
                    {
                        waterWasted += bottles.Pop() - cupCapacity;
                        cups.Dequeue();
                        cupCapacity = 0;
                    }
                    else
                    {
                        cupCapacity -= bottles.Pop();
                    }

                    if (bottles.Count == 0)
                    {
                        Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                        break;
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {waterWasted}");
        }
    }
}
