using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double aquariumCapacity = length * height * width;
            double totalLiters = aquariumCapacity * 0.001;
            double calculatedPercent = percent * 0.01;
            double litersNeeded = totalLiters * (1 - calculatedPercent);

            Console.WriteLine("{0:F3}",litersNeeded);

        }
    }
}
