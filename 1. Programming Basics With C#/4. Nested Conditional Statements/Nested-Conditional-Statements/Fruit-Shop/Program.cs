using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double bananaPriceWeekdays = 2.50;
            double applePriceWeekdays = 1.20;
            double orangePriceWeekdays = 0.85;
            double grapefruitPriceWeekdays = 1.45;
            double kiwiPriceWeekdays = 2.70;
            double pineapplePriceWeekdays = 5.50;
            double grapesPriceWeekdays = 3.85;

            double bananaPriceWeekend = 2.70;
            double applePriceWeekend = 1.25;
            double orangePriceWeekend = 0.90;
            double grapefruitPriceWeekend = 1.60;
            double kiwiPriceWeekend = 3.00;
            double pineapplePriceWeekend = 5.60;
            double grapesPriceWeekend = 4.20;

            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0.0;

            if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" ||
                dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" ||
                dayOfWeek == "Friday")
            {
                if (fruit == "banana")
                {
                    price = bananaPriceWeekdays;
                }
                else if (fruit == "apple")
                {
                    price = applePriceWeekdays;
                }
                else if (fruit == "orange")
                {
                    price = orangePriceWeekdays;
                }
                else if (fruit == "grapefruit")
                {
                    price = grapefruitPriceWeekdays;
                }
                else if (fruit == "kiwi")
                {
                    price = kiwiPriceWeekdays;
                }
                else if (fruit == "pineapple")
                {
                    price = pineapplePriceWeekdays;
                }
                else if (fruit == "grapes")
                {
                    price = grapesPriceWeekdays;
                }
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                if (fruit == "banana")
                {
                    price = bananaPriceWeekend;
                }
                else if (fruit == "apple")
                {
                    price = applePriceWeekend;
                }
                else if (fruit == "orange")
                {
                    price = orangePriceWeekend;
                }
                else if (fruit == "grapefruit")
                {
                    price = grapefruitPriceWeekend;
                }
                else if (fruit == "kiwi")
                {
                    price = kiwiPriceWeekend;
                }
                else if (fruit == "pineapple")
                {
                    price = pineapplePriceWeekend;
                }
                else if (fruit == "grapes")
                {
                    price = grapesPriceWeekend;
                }
            }

            if (price > 0.0)
            {
                Console.WriteLine($"{price * quantity:F2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
