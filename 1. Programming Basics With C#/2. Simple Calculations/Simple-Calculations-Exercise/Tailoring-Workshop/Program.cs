using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTables = int.Parse(Console.ReadLine());
            double lenghtOfTables = double.Parse(Console.ReadLine());
            double widthOfTables = double.Parse(Console.ReadLine());

            double areaOfRectangleCovering = numberOfTables * (lenghtOfTables + 2 * 0.30) * (widthOfTables + 2 * 0.30);
            double areaOfSquareCovering = numberOfTables * (lenghtOfTables / 2) * (lenghtOfTables / 2);

            double usdPriceRectCovering = areaOfRectangleCovering * 7;
            double usdPriceSquareCovering = areaOfSquareCovering * 9;
            double usdTotalPrice = usdPriceRectCovering + usdPriceSquareCovering;

            double bgnTotalPrice = usdTotalPrice * 1.85;

            Console.WriteLine($"{usdTotalPrice:F2} USD");
            Console.WriteLine($"{bgnTotalPrice:F2} BGN");

        }
    }
}
