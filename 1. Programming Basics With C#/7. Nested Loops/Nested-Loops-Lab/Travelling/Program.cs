using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            while (destination != "End")
            {              
                double budgetForDestination = double.Parse(Console.ReadLine());
                double currentMoney = 0;
                for (double savedMoney = 0; savedMoney < budgetForDestination; savedMoney += currentMoney)
                {
                    currentMoney = double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }           
        }
    }
}
