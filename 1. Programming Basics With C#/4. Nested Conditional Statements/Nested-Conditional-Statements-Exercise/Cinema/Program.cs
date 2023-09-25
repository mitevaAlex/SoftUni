using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double premiere = 12.00;
            double normal = 7.50;
            double discount = 5.00;
            double income = 0.0;
            int seats = rows * columns;

            if (type == "Premiere")
            {
                income = premiere * seats;
            }
            else if (type == "Normal")
            {
                income = normal * seats;
            }
            else if (type == "Discount")
            {
                income = discount * seats;
            }

            Console.WriteLine($"{income:F2}");
        }
    }
}
