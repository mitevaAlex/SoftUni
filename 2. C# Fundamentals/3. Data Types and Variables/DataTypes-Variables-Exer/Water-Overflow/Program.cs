using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int timesPouringWater = int.Parse(Console.ReadLine());//the lines we are going to read
            int waterTankCapacity = 255;
            int litresInTheTank = 0;
            for (int currentPouring = 0; currentPouring < timesPouringWater; currentPouring++)
            {
                int currentLitres = int.Parse(Console.ReadLine());
                if (waterTankCapacity - currentLitres < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                waterTankCapacity -= currentLitres;
                litresInTheTank += currentLitres;
            }
            Console.WriteLine(litresInTheTank);
        }
    }
}
