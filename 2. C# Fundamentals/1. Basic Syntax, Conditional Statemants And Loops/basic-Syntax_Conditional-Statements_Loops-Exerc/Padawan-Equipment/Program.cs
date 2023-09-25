using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int totalLightsabers = studentsCount;
            int additionalLightsabers = (int)Math.Ceiling(1 / 10.0 * studentsCount);
            int totalBelts = studentsCount;
            int freeBelts = studentsCount / 6;
            int robesCount = studentsCount;

            double totalPrice = (totalLightsabers + additionalLightsabers) * lightsaberPrice +
                (totalBelts - freeBelts) * beltPrice + robesCount * robePrice;

            if (money >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                double moneyNeeded = totalPrice - money;
                Console.WriteLine($"Ivan Cho will need {moneyNeeded:f2}lv more.");
            }
        }
    }
}
