using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBreadsCount = int.Parse(Console.ReadLine());
            int maxGramsSugarUsed = 0;
            int maxGramsFlourUsed = 0;
            int totalSugarNeeded = 0;
            int totalFlourNeeded = 0;
            for (int currentEatserBread = 1; currentEatserBread <= easterBreadsCount; currentEatserBread++)
            {
                int currentGramsSugar = int.Parse(Console.ReadLine());
                int currentGramsFlour = int.Parse(Console.ReadLine());
                totalSugarNeeded += currentGramsSugar;
                totalFlourNeeded += currentGramsFlour;

                if (currentGramsSugar > maxGramsSugarUsed)
                {
                    maxGramsSugarUsed = currentGramsSugar;
                }
                if (currentGramsFlour > maxGramsFlourUsed)
                {
                    maxGramsFlourUsed = currentGramsFlour;
                }
            }

            double packetsSugarNeeded = Math.Ceiling(totalSugarNeeded / 950.0);
            double packetsFlourNeeded = Math.Ceiling(totalFlourNeeded / 750.0);

            Console.WriteLine($"Sugar: {packetsSugarNeeded}");
            Console.WriteLine($"Flour: {packetsFlourNeeded}");
            Console.WriteLine($"Max used flour is {maxGramsFlourUsed} grams, max used sugar is {maxGramsSugarUsed} grams.");
        }
    }
}
