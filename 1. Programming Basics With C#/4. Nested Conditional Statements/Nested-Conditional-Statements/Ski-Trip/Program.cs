using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeAccommodation = Console.ReadLine();
            string rating = Console.ReadLine();

            double priceRoomForOnePersonPerNight = 18.0;
            double priceApartmentPerNight = 25.0;
            double pricePresidentApartmentPerNight = 35.0;
            double totalPrice = 0.0;
            int nights = days - 1;

            if (typeAccommodation == "room for one person")
            {
                totalPrice = nights * priceRoomForOnePersonPerNight;
            }
            else if (typeAccommodation == "apartment")
            {
                totalPrice = nights * priceApartmentPerNight;

                if (days < 10)
                {
                    totalPrice *= 0.70;
                }
                else if (days >= 10 && days <= 15)
                {
                    totalPrice *= 0.65;
                }
                else if (days > 15)
                {
                    totalPrice *= 0.50; 
                }
            }
            else if (typeAccommodation == "president apartment")
            {
                totalPrice = nights * pricePresidentApartmentPerNight;

                if (days < 10)
                {
                    totalPrice *= 0.90;
                }
                else if (days >= 10 && days <= 15)
                {
                    totalPrice *= 0.85;
                }
                else if (days > 15)
                {
                    totalPrice *= 0.80;
                }
            }

            if (rating == "positive")
            {
                totalPrice *= 1.25;
            }
            else if (rating == "negative")
            {
                totalPrice *= 0.90;
            }

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
