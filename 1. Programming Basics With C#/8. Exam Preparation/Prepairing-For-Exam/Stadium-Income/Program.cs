using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stadium_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            int stadiumSectors = int.Parse(Console.ReadLine());
            int stadiumCapacity = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double totalIncome = stadiumCapacity * ticketPrice;
            double moneyFromOneSector = totalIncome / stadiumSectors;
            double moneyForCharity = (totalIncome - 0.75 * moneyFromOneSector) / 8;

            Console.WriteLine($"Total income - {totalIncome:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
        }
    }
}
