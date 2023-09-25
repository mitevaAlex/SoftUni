using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string holidayDates = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            int totalHolidayPrice = 0;
            int oneNightPrice = 0;

            if (destination == "France")
            {
                if (holidayDates == "21-23")
                {
                    oneNightPrice = 30;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
                else if (holidayDates == "24-27")
                {
                    oneNightPrice = 35;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
                else if (holidayDates == "28-31")
                {
                    oneNightPrice = 40;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
            }
            else if (destination == "Italy")
            {
                if (holidayDates == "21-23")
                {
                    oneNightPrice = 28;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
                else if (holidayDates == "24-27")
                {
                    oneNightPrice = 32;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
                else if (holidayDates == "28-31")
                {
                    oneNightPrice = 39;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
            }
            else if (destination == "Germany")
            {
                if (holidayDates == "21-23")
                {
                    oneNightPrice = 32;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
                else if (holidayDates == "24-27")
                {
                    oneNightPrice = 37;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
                else if (holidayDates == "28-31")
                {
                    oneNightPrice = 43;
                    totalHolidayPrice = nightsCount * oneNightPrice;
                }
            }

            Console.WriteLine($"Easter trip to {destination} : {totalHolidayPrice:F2} leva.");
        }
    }
}
