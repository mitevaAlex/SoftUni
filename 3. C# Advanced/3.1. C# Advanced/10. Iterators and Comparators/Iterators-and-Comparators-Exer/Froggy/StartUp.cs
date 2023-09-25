using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            List<int> frogPathStones = new List<int>();
            for (int i = 0; i < lake.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    frogPathStones.Add(lake[i]);
                }
            }

            for (int i = lake.Count() - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    frogPathStones.Add(lake[i]);
                }
            }

            Console.WriteLine(string.Join(", ", frogPathStones));
        }
    }
}
