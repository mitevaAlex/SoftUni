using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int fishQuota = int.Parse(Console.ReadLine());
            int fishCount = 0;            
            double moneyWon = 0.0;
            double moneyLost = 0.0;
            string fishName = Console.ReadLine();

            while (fishName != "Stop")
            {
                if (fishCount < fishQuota)
                {
                    double currentFishKilograms = double.Parse(Console.ReadLine());
                    fishCount++;
                    double moneyWonOrLost = 0.0;
                    for (int nameLetterPosition = 0; nameLetterPosition < fishName.Length; nameLetterPosition++)
                    {
                        int nameLetter = fishName[nameLetterPosition];
                        moneyWonOrLost += nameLetter;
                    }
                    moneyWonOrLost /= currentFishKilograms;
                    if (fishCount % 3 == 0)
                    {
                        moneyWon += moneyWonOrLost;
                    }
                    else
                    {
                        moneyLost += moneyWonOrLost;
                    }

                    if (fishCount < fishQuota)
                    {
                        fishName = Console.ReadLine();
                    }                   
                }
                else
                {
                    Console.WriteLine($"Lyubo fulfilled the quota!");
                    break;
                }                   
            }
                     
            double actualMoneyWonOrLost = Math.Abs(moneyWon - moneyLost);
            if (moneyWon >= moneyLost)
            {                
                Console.WriteLine($"Lyubo's profit from {fishCount} fishes is {actualMoneyWonOrLost:F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {actualMoneyWonOrLost:F2} leva today.");     
            }

        }
    }
}
