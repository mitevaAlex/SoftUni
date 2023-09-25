using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_shop
{
    class Program
    {
        static void Main(string[] args)
        {
             double coffeeSofia =0.50 ;
             double waterSofia = 0.80;
             double beerSofia =1.20 ;
             double sweetsSofia =1.45 ;
            double peanutsSofia = 1.60;

            double coffeePlovdiv = 0.40;
            double waterPlovdiv = 0.70;
            double beerPlovdiv = 1.15;
            double sweetsPlovdiv = 1.30;
            double peanutsPlovdiv = 1.50;

            double coffeeVarna = 0.45;
            double waterVarna = 0.70;
            double beerVarna = 1.10;
            double sweetsVarna = 1.35;
            double peanutsVarna = 1.55;

            double price = 0.0;

            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());

            if (town == "Sofia")
            {
                if(product == "water")
                {
                    price = count * waterSofia;
                }
                else if (product == "coffee")
                {
                    price = count * coffeeSofia;
                }
                else if (product == "beer")
                {
                    price = count * beerSofia;
                }
                else if (product == "sweets")
                {
                    price = count * sweetsSofia;
                }
                else if (product == "peanuts")
                {
                    price = count * peanutsSofia;
                }

            }
            else if (town == "Plovdiv")
            {
                if (product == "water")
                {
                    price = count * waterPlovdiv;
                }
                else if (product == "coffee")
                {
                    price = count * coffeePlovdiv;
                }
                else if (product == "beer")
                {
                    price = count * beerPlovdiv;
                }
                else if (product == "sweets")
                {
                    price = count * sweetsPlovdiv;
                }
                else if (product == "peanuts")
                {
                    price = count * peanutsPlovdiv;
                }

            }
            else if (town  == "Varna")
            {
                if (product == "water")
                {
                    price = count * waterVarna;
                }
                else if (product == "coffee")
                {
                    price = count * coffeeVarna;
                }
                else if (product == "beer")
                {
                    price = count * beerVarna;
                }
                else if (product == "sweets")
                {
                    price = count * sweetsVarna;
                }
                else if (product == "peanuts")
                {
                    price = count * peanutsVarna;
                }

            }
            Console.WriteLine(price);

        }
    }
}
