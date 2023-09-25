using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();

            double inputInMeters = 0;

            if (inputMetric == "m")
            {
                inputInMeters = input;
            }
            else if (inputMetric == "mm")
            {
                inputInMeters = input / 1000;
            }
            else if (inputMetric == "cm")
            {
                inputInMeters = input / 100;
            }

            double output = 0;

            if (outputMetric == "m")
            {
                output = inputInMeters;
            }
            else if (outputMetric == "mm")
            {
                output = inputInMeters * 1000;
            }
            else if(outputMetric == "cm")
            {
                output = inputInMeters * 100;
            }

            Console.WriteLine($"{output:F3}");
        }
    }
}
