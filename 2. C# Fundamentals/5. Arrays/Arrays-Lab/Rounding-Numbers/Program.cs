using System;
using System.Linq;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubleNumbers = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < doubleNumbers.Length; i++)
            {
                int roundedNumber = (int)Math.Round(doubleNumbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{doubleNumbers[i]} => {roundedNumber}");
            }
        }
    }
}
