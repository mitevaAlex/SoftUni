using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceStudioPerNight = 0.0;
            double priceApartmentPerNight = 0.0;
            double totalPriceStudio = 0.0;
            double totalPriceApartment = 0.0;

            if (month == "May" || month == "October")
            {
                priceStudioPerNight = 50.0;
                priceApartmentPerNight = 65.0;
                totalPriceStudio = nights * priceStudioPerNight;
                totalPriceApartment = nights * priceApartmentPerNight;

                if (nights > 7 && nights <= 14)
                {
                    totalPriceStudio *= 95 / 100.0;
                }
                else if (nights > 14)
                {
                    totalPriceStudio *= 70 / 100.0;
                    totalPriceApartment *= 90 / 100.0;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceStudioPerNight = 75.20;
                priceApartmentPerNight = 68.70;
                totalPriceStudio = nights * priceStudioPerNight;
                totalPriceApartment = nights * priceApartmentPerNight;

                if (nights > 14)
                {
                    totalPriceStudio *= 80 / 100.0;
                    totalPriceApartment *= 90 / 100.0;
                }
            }
            else if (month == "July" || month == "August")
            {
                priceStudioPerNight = 76.0;
                priceApartmentPerNight = 77.0;
                totalPriceStudio = nights * priceStudioPerNight;
                totalPriceApartment = nights * priceApartmentPerNight;

                if (nights > 14)
                {
                    totalPriceApartment *= 90 / 100.0;
                }
            }

            Console.WriteLine($"Apartment: {totalPriceApartment:F2} lv.");
            Console.WriteLine($"Studio: {totalPriceStudio:F2} lv.");
        }
    }
}
