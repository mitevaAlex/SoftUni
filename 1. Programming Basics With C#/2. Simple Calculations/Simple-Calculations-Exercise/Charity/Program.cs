using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            double cakePrice = 45;
            double wafflePrice = 5.80;
            double pancakePrice = 3.20;

            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double totalPrice = days * (bakers * ((cakes * cakePrice) + (waffles * wafflePrice) + (pancakes * pancakePrice)));
            double priceAfterExpenses = totalPrice - totalPrice / 8;

            Console.WriteLine($"{priceAfterExpenses:F2}");
        }
    }
}
