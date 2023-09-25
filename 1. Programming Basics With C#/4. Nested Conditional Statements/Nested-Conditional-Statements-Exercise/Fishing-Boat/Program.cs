using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenCount = int.Parse(Console.ReadLine());

            double price = 0.0;

            if (season == "Spring")
            {
                price = 3000.0;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                price = 4200.0;
            }
            else if (season == "Winter")
            {
                price = 2600.0;
            }

            if (fishermenCount <= 6)
            {
                price *= 0.90;
            }
            else if (fishermenCount >= 7 && fishermenCount <= 11)
            {
                price *= 0.85;
            }
            else
            {
                price *= 0.75;
            }

            if (fishermenCount % 2 == 0 && season != "Autumn")
            {
                price *= 0.95;
            }

            double moneyLeftOrNeeded = Math.Abs(budget - price);

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {moneyLeftOrNeeded:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moneyLeftOrNeeded:F2} leva.");
            }
        }
    }
}
