using System;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            int potatoPasses = int.Parse(Console.ReadLine());
            while (children.Count > 1)
            {
                for (int i = 0; i < potatoPasses - 1; i++)
                {
                    string currentChild = children.Dequeue();
                    children.Enqueue(currentChild);
                    //or: children.Enqueue(children.Dequeue());
                }

                string loser = children.Dequeue();
                Console.WriteLine($"Removed {loser}");
            }

            string winner = children.Dequeue();
            Console.WriteLine($"Last is {winner}");
        }
    }
}
