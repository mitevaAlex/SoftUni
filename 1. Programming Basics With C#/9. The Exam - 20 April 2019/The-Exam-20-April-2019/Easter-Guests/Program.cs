using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double easterBreadsNeeded = Math.Ceiling(guestsCount / 3.0);
            int eggsNeeded = guestsCount * 2;
            double easterBreadsPrice = easterBreadsNeeded * 4;
            double eggsPrice = eggsNeeded * 0.45;
            double totalPrice = easterBreadsPrice + eggsPrice;

            double moneyLeftOrNeeded = Math.Abs(totalPrice - budget);
            if (totalPrice <= budget)
            {
                Console.WriteLine($"Lyubo bought {easterBreadsNeeded} Easter bread and {eggsNeeded} eggs.");
                Console.WriteLine($"He has {moneyLeftOrNeeded:F2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {moneyLeftOrNeeded:F2} lv. more.");
            }
        }
    }
}
