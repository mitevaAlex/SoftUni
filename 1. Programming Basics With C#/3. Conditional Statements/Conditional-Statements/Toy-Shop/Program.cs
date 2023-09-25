using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzlePrice = 2.60;
            double dollPrice = 3;
            double teddyBearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2;

            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double totalProfit = puzzlesCount * puzzlePrice + dollsCount * dollPrice + teddyBearsCount * teddyBearPrice
                + minionsCount * minionPrice + trucksCount * truckPrice;

            if (puzzlesCount + dollsCount + teddyBearsCount + minionsCount + trucksCount >= 50)
            {
                totalProfit = totalProfit - 0.25 * totalProfit;
            }

            double profitAfterRent = totalProfit - 0.1 * totalProfit;
            
            if (profitAfterRent >= tripPrice)
            {
                double leftMoney = profitAfterRent - tripPrice;
                Console.WriteLine($"Yes! {leftMoney:F2} lv left.");
            }
            else
            {
                double moneyNeeded = tripPrice - profitAfterRent;
                Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
            }
        }

    }
}
