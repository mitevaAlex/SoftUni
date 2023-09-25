using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int boxesCount = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < boxesCount; i++)
            {
                boxes.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }

            int[] swapIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Swap(boxes, swapIndexes);
            Console.WriteLine(string.Join(Environment.NewLine, boxes));
        }

        static void Swap<T>(List<T> items, int[] indexes)
        {
            T firstItem = items[indexes[0]];
            items[indexes[0]] = items[indexes[1]];
            items[indexes[1]] = firstItem;
        }
    }
}
