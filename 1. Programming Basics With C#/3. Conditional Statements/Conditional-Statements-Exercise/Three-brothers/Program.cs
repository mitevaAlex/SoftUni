using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBrotherHours = double.Parse(Console.ReadLine());
            double secondBrotherHours = double.Parse(Console.ReadLine());
            double thirdBrotherHours = double.Parse(Console.ReadLine());
            double fatherAbsentHours = double.Parse(Console.ReadLine());

            double timeNeeded = 1 / (1 / firstBrotherHours + 1 / secondBrotherHours + 1 / thirdBrotherHours);
            timeNeeded += 0.15 * timeNeeded;
            double timeLeft = fatherAbsentHours - timeNeeded;

            Console.WriteLine($"Cleaning time: {timeNeeded:F2}");

            if (timeLeft >= 0)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft)} hours.");
            }
            else
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(Math.Abs(timeLeft))} hours.");
            }

        }
    }
}
