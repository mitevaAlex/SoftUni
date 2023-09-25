using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beerLitres = double.Parse(Console.ReadLine());
            double wineLitres = double.Parse(Console.ReadLine());
            double rakiaLitres = double.Parse(Console.ReadLine());
            double whiskeyLitres = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskeyPrice / 2;
            double winePrice = rakiaPrice - (40.0/100.0 * rakiaPrice);
            double beerPrice = rakiaPrice - (80.0/100.0 * rakiaPrice);

            double totalWhiskeyPrice = whiskeyPrice * whiskeyLitres;
            double totalBeerPrice = beerPrice * beerLitres;
            double totalWinePrice = winePrice * wineLitres;
            double totalRakiaPrice = rakiaPrice * rakiaLitres;

            double totalPrice = totalWhiskeyPrice + totalBeerPrice + totalWinePrice + totalRakiaPrice;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
