using System;

namespace The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayPerPerson = double.Parse(Console.ReadLine());
            double foodPerDayPerPerson = double.Parse(Console.ReadLine());

            double totalWater = waterPerDayPerPerson * playersCount * daysCount;
            double totalFood = foodPerDayPerPerson * playersCount * daysCount;
            bool isEnergyEnough = true;
            for (int i = 1; i <= daysCount; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoss;
                if (groupEnergy <= 0)
                {
                    isEnergyEnough = false;
                    break;
                }

                if (i % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    totalWater *= 0.7;
                }

                if (i % 3 == 0)
                {
                    groupEnergy *= 1.1;
                    totalFood -= totalFood / playersCount;
                }
            }

            if (isEnergyEnough)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
            }
        }
    }
}
