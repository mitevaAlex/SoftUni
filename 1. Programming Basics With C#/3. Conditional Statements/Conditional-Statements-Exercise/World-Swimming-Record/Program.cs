using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double secondsDelay = Math.Floor(distanceMeters / 15.0) * 12.5;
            double totalSeconds = distanceMeters * secondsPerMeter + secondsDelay;
            double secondsMore = totalSeconds - worldRecordSeconds;

            if (worldRecordSeconds <= totalSeconds)
            {
                Console.WriteLine($"No, he failed! He was {secondsMore:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalSeconds:F2} seconds.");
            }

        }
    }
}
