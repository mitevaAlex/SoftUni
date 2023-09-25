using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = string.Empty;
            string typeHoliday = string.Empty;
            double price = 0.0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    typeHoliday = "Camp";
                    price = 30 / 100.0 * budget;
                }
                else if (season == "winter")
                {
                    typeHoliday = "Hotel";
                    price = 70 / 100.0 * budget;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    typeHoliday = "Camp";
                    price = 40 / 100.0 * budget;
                }
                else if (season == "winter")
                {
                    typeHoliday = "Hotel";
                    price = 80 / 100.0 * budget;
                }
            }
            else
            {
                destination = "Europe";
                typeHoliday = "Hotel";
                price = 90 / 100.0 * budget;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeHoliday} - {price:F2}");
        }
    }
}
