using System;

namespace Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] coordinates = new double[4];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = double.Parse(Console.ReadLine());
            }
            FindTheClosestToCentrePoint(coordinates);
        }

        static void FindTheClosestToCentrePoint(double[] coordinates)
        {
            double x1 = coordinates[0];
            double y1 = coordinates[1];
            double x2 = coordinates[2];
            double y2 = coordinates[3];
            double[] closestPoint = new double[2];
            double firstDistance = Math.Abs(Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)));
            double secondDistance = Math.Abs(Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)));

            if (firstDistance <= secondDistance)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
