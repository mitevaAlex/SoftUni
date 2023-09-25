using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFoodAvailable = int.Parse(Console.ReadLine());
            Queue<int> quantitiesOfOrders = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Console.WriteLine(quantitiesOfOrders.Max());
            while (quantitiesOfOrders.Count > 0)
            {
                if (quantitiesOfOrders.Peek() <= quantityFoodAvailable)
                {
                    quantityFoodAvailable -= quantitiesOfOrders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(quantitiesOfOrders.Count == 0 ? "Orders complete" : $"Orders left: {string.Join(' ', quantitiesOfOrders)}");
        }
    }
}
