using System;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"%(?<name>[A-Z][a-z]+)%[^.|$%]*<(?<product>\w+)>[^.|$%]*\|(?<quantity>\d+)\|[^.|$%]*?(?<price>\d+\.?\d*)\$");
            string command = string.Empty;
            double totalIncome = 0.0;
            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match orderArgs = regex.Match(command);
                if (orderArgs.Success)
                {
                    double totalPrice = double.Parse(orderArgs.Groups["price"].Value) *
                        int.Parse(orderArgs.Groups["quantity"].Value);
                    totalIncome += totalPrice;
                    Console.WriteLine($"{orderArgs.Groups["name"].Value}: {orderArgs.Groups["product"].Value} - {totalPrice:F2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
