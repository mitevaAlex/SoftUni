using System;

namespace Debug
{
    public class DebugMe
    {
        public static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            int timePerMeter = int.Parse(Console.ReadLine());

            double timeInSeconds = distance * 25;
            double additionalSeconds = (distance / 50);
            additionalSeconds = Math.Ceiling(additionalSeconds);
            additionalSeconds *= 30;
            double totalTime = timeInSeconds + additionalSeconds;

            if (worldRecord <= totalTime)
            {
                Console.WriteLine($"Yes! The new record is {totalTime} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(worldRecord - totalTime):f2} seconds slower.");
            }
        }
    }
}