using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int savedMoney = 0;
            int toysCount = 0;
            int moneyFromToys = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += 10 * (i / 2) - 1;
                }
                else
                {
                    toysCount++;
                }
            }
            moneyFromToys = toysCount * toyPrice;
            savedMoney += moneyFromToys;
            double moneyLeftOrNeeded = Math.Abs(washingMachinePrice - savedMoney);

            if (washingMachinePrice <= savedMoney)
            {
                Console.WriteLine($"Yes! {moneyLeftOrNeeded:F2}");
            }
            else
            {
                Console.WriteLine($"No! {moneyLeftOrNeeded:F2}");
            }
        }
    }
}
