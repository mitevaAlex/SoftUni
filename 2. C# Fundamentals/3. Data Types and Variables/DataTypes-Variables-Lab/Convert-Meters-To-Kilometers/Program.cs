using System;

namespace Convert_Meters_To_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            double distanceInKilometers = distanceInMeters / 1000.0;
            Console.WriteLine($"{distanceInKilometers:F2}");
        }
    }
}
