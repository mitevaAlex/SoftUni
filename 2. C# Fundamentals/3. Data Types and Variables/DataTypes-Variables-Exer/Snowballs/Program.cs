using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballsMade = int.Parse(Console.ReadLine());
            int highestSnowballSnow = 0;
            int highestSnowballTime = 0;
            int highestSnowballQuality = 0;
            BigInteger highestSnowballValue = 0;
            for (int currentSnowball = 1; currentSnowball <= snowballsMade; currentSnowball++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentSnowballValue = BigInteger.Pow(currentSnowballSnow / currentSnowballTime, currentSnowballQuality);

                if (currentSnowballValue > highestSnowballValue)
                {
                    highestSnowballValue = currentSnowballValue;
                    highestSnowballSnow = currentSnowballSnow;
                    highestSnowballTime = currentSnowballTime;
                    highestSnowballQuality = currentSnowballQuality;
                }
            }
            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue} ({highestSnowballQuality})");
        }
    }
}
