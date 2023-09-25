using System;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daysOperated = 0;
            int totalAmountOfSpice = 0;
            int workersConsumption = 26;//workers consume 26 spice every day and 26 spice after leaving the mine
            int yieldDropdown = 10;//the yield drops with 10 spice after each day
            for (int currentYield = startingYield; currentYield >= 100; currentYield -= yieldDropdown)
            {
                totalAmountOfSpice += currentYield - workersConsumption;
                daysOperated++;
            }
            if (totalAmountOfSpice - workersConsumption >= 0)
            {
                totalAmountOfSpice -= workersConsumption;
            }
            Console.WriteLine(daysOperated);
            Console.WriteLine(totalAmountOfSpice);
        }
    }
}
