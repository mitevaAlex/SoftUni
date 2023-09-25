using System;

namespace Pounds_To_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double britishPounds = double.Parse(Console.ReadLine());
            double dollarsUS = britishPounds * 1.31;
            Console.WriteLine($"{dollarsUS:F3}");
        }
    }
}
