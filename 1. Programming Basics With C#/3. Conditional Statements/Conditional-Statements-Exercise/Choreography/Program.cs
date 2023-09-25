using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int danceSteps = int.Parse(Console.ReadLine());
            int dancersCount = int.Parse(Console.ReadLine());
            int availableDays = int.Parse(Console.ReadLine());

            double stepsPerDay = danceSteps / availableDays;
            double percentStepsPerDay = Math.Ceiling(stepsPerDay/ danceSteps * 100);
            double percentPerPersonPerDay = percentStepsPerDay /dancersCount;
            
            if (percentStepsPerDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentPerPersonPerDay:F2}%.");
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {percentPerPersonPerDay:F2}% steps to be learned per day.");
            }
        }
    }
}
