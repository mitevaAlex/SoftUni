using System;

namespace Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsCount = int.Parse(Console.ReadLine());
            double stepLength = double.Parse(Console.ReadLine());//in centimeters
            int distance = int.Parse(Console.ReadLine());//in meters
            double travelledDistance = 0.0;//in centimeters
            for (int i = 1; i <= stepsCount; i++)
            {
                double currentStep = stepLength;
                if (i % 5 == 0)
                {
                    currentStep *= 0.7;
                }
                travelledDistance += currentStep;
            }
            travelledDistance /= 100;
            double distanceTravelledPercent = travelledDistance / distance * 100;
            Console.WriteLine($"You travelled {distanceTravelledPercent:F2}% of the distance!");
        }
    }
}
