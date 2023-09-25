using System;

namespace Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] coordinates = new double[8];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = double.Parse(Console.ReadLine());
            }

            double firstLineLength = FindLineLength(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
            double secondLineLength = FindLineLength(coordinates[4], coordinates[5], coordinates[6], coordinates[7]);

            if (firstLineLength >= secondLineLength)
            {
                bool isFirstPointCloser = IsFirstPointCloser(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
                if (isFirstPointCloser)
                {
                    Console.WriteLine($"({coordinates[0]}, {coordinates[1]})({coordinates[2]}, {coordinates[3]})");
                }
                else
                {
                    Console.WriteLine($"({coordinates[2]}, {coordinates[3]})({coordinates[0]}, {coordinates[1]})");
                }
            }
            else
            {
                bool isFirstPointCloser = IsFirstPointCloser(coordinates[4], coordinates[5], coordinates[6], coordinates[7]);
                if (isFirstPointCloser)
                {
                    Console.WriteLine($"({coordinates[4]}, {coordinates[5]})({coordinates[6]}, {coordinates[7]})");
                }
                else
                {
                    Console.WriteLine($"({coordinates[6]}, {coordinates[7]})({coordinates[4]}, {coordinates[5]})");
                }
            }
        }

        static double FindLineLength(double x1, double y1, double x2, double y2)
        {
            double lineLength = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return lineLength;
        }

        static bool IsFirstPointCloser(double x1, double y1, double x2, double y2)
        {
            double[] closestPoint = new double[2];
            double firstDistance = Math.Abs(Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)));
            double secondDistance = Math.Abs(Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)));

            if (firstDistance <= secondDistance)
            {
                return true;
            }
            return false;
        }
    }
}
