using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());
            List<string> elements = new List<string>();
            for (int i = 0; i < elementsCount; i++)
            {
                elements.Add(Console.ReadLine());
            }

            string comparisonElement = Console.ReadLine();
            int countGreaterThan = CountGreater(elements, comparisonElement);
            Console.WriteLine(countGreaterThan);
        }

        static int CountGreater<T>(List<T> elements, T element)
            where T : IComparable
        {
            int count = elements.Where(x => x.CompareTo(element) == 1).Count();
            return count;
        }
    }
}
