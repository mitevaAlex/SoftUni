using System;
using System.Collections.Generic;
using System.Linq;

namespace Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initialDrumsQuality = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> currentDrumsQuality = new List<int>();
            foreach (int currentQuality in initialDrumsQuality)
            {
                currentDrumsQuality.Add(currentQuality);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine())!= "Hit it again, Gabsy!")
            {
                int currentHitPower = int.Parse(command);
                for (int i = 0; i < currentDrumsQuality.Count; i++)
                {
                    currentDrumsQuality[i] -= currentHitPower;
                    if (currentDrumsQuality[i] <= 0 && savings >= initialDrumsQuality[i] * 3)
                    {
                        currentDrumsQuality[i] = initialDrumsQuality[i];
                        savings -= initialDrumsQuality[i] * 3;
                    }
                    else if (currentDrumsQuality[i] <= 0 && savings < initialDrumsQuality[i] * 3)
                    {
                        currentDrumsQuality.RemoveAt(i);
                        initialDrumsQuality.RemoveAt(i);
                        i--;
                    }
                }
            }
            Console.WriteLine(string.Join(' ', currentDrumsQuality));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
