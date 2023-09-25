using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int cookieBatchesCount = int.Parse(Console.ReadLine());
             
            bool containingFlour = false;
            bool containingEggs = false;
            bool containingSugar = false;

            for (int currentBatchNumber = 1; currentBatchNumber <= cookieBatchesCount; currentBatchNumber++)
            {
                string ingredient = Console.ReadLine();
                while (ingredient != "Bake!")
                {                    
                    if (ingredient == "flour") containingFlour = true;
                    if (ingredient == "eggs") containingEggs = true;
                    if (ingredient == "sugar") containingSugar = true;
                    ingredient = Console.ReadLine();
                }

                if (containingFlour && containingEggs && containingSugar)
                {
                    Console.WriteLine($"Baking batch number {currentBatchNumber}...");
                    containingFlour = false;
                    containingEggs = false;
                    containingSugar = false;
                }
                else
                {
                    currentBatchNumber--;
                    Console.WriteLine($"The batter should contain flour, eggs and sugar!");
                }
            }
            
        }
    }
}
