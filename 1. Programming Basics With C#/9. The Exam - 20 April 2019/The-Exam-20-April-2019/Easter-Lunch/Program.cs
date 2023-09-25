using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBreadsCount = int.Parse(Console.ReadLine());
            int cartonsOfEggsCount = int.Parse(Console.ReadLine());
            int cookiesKilograms = int.Parse(Console.ReadLine());

            double totalEasterBreadsPrice = easterBreadsCount * 3.2;
            double totalEggsPrice = cartonsOfEggsCount * 4.35;
            double totalCookiesPrice = cookiesKilograms * 5.40;
            double totalPaintForEggsPrice = cartonsOfEggsCount * 12 * 0.15;

            double totalLunchPrice = totalEasterBreadsPrice + totalEggsPrice + totalCookiesPrice + totalPaintForEggsPrice;
            Console.WriteLine($"{totalLunchPrice:F2}");
        }
    }
}
