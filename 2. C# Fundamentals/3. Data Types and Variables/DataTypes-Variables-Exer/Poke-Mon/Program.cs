using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());//the power of the poke mon to reach the next target
            int distance = int.Parse(Console.ReadLine());//the distance between the poke targets
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int targetsPoked = 0;
            double halfOfTheStartingPower = pokePower * 0.5;
            while (pokePower >= distance)
            {               
                pokePower -= distance;
                targetsPoked++;

                if (pokePower == halfOfTheStartingPower && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;     
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(targetsPoked);
        }
    }
}
