using System;

namespace Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = FindRectangleArea(width, height);
            Console.WriteLine(area);
        }

        static double FindRectangleArea(double width, double height)
        {
            double area = width * height;
            return area;
        }
    }
}
