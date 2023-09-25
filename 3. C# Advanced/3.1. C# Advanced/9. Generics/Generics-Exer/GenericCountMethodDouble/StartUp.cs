using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();
            for (int i = 0; i < elementsCount; i++)
            {
                elements.Add(double.Parse(Console.ReadLine()));
            }

            double comparisonElement = double.Parse(Console.ReadLine());
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
