using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVAT = x => x * 1.2M;
            decimal[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(addVAT)
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, prices.Select(x => $"{x:F2}")));
        }
    }
}
