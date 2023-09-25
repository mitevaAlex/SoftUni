using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer_And_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beersCount = int.Parse(Console.ReadLine());
            int crispsCount = int.Parse(Console.ReadLine());

            double bottleBeerPrice = 1.20;
            double totalBeerPrice = bottleBeerPrice * beersCount;
            double totalCrispsPrice = Math.Ceiling(0.45 * totalBeerPrice * crispsCount);
            double totalPrice = totalBeerPrice + totalCrispsPrice;

            double moneyLeftOrNeeded = Math.Abs(budget - totalPrice);
            if (budget >= totalPrice)
            {
                Console.WriteLine($"{name} bought a snack and has {moneyLeftOrNeeded:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {moneyLeftOrNeeded:F2} more leva!");
            }
        }
    }
}
