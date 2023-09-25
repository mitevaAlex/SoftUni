using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int holidaysCount = int.Parse(Console.ReadLine());
            int weekendHomeTrips = int.Parse(Console.ReadLine());
            int weekendsPerYear = 48;

            decimal volleyballInSofia = (decimal) (3/4.0 * (weekendsPerYear - weekendHomeTrips) + (2 / 3.0 * holidaysCount));
            int volleyballInHomeTown = weekendHomeTrips;

            decimal totalVolleyball = volleyballInSofia + volleyballInHomeTown;

            if (yearType == "leap")
            {
                totalVolleyball *= 1.15M;
            }

            Console.WriteLine(Math.Floor(totalVolleyball));
        }
    }
}
