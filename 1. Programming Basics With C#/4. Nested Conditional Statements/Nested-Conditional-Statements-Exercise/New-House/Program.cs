using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double rosePrice = 5.00;
            double dahliaPrice = 3.80;
            double tulipPrice = 2.80;
            double narcissusPrice = 3.00;
            double gladiolusPrice = 2.50;

            double totalPrice = 0.0;

            if (flowersType == "Roses")
            {
                if (flowersCount > 80)
                {
                    totalPrice = 0.90 * (flowersCount * rosePrice);

                }
                else
                {
                    totalPrice = flowersCount * rosePrice;
                }
            }
            else if (flowersType == "Dahlias")
            {
                if (flowersCount > 90)
                {
                    totalPrice = 0.85 * (flowersCount * dahliaPrice);
                }
                else
                {
                    totalPrice = flowersCount * dahliaPrice;
                }
            }
            else if (flowersType == "Tulips")
            {
                if (flowersCount > 80)
                {
                    totalPrice = 0.85 * (flowersCount * tulipPrice);
                }
                else
                {
                    totalPrice = flowersCount * tulipPrice;
                }
            }
            else if (flowersType == "Narcissus")
            {
                if (flowersCount < 120)
                {
                    totalPrice = 1.15 * (flowersCount * narcissusPrice);
                }
                else
                {
                    totalPrice = flowersCount * narcissusPrice;
                }
            }
            else if (flowersType == "Gladiolus")
            {
                if (flowersCount < 80)
                {
                    totalPrice = 1.20 * (flowersCount * gladiolusPrice);
                }
                else
                {
                    totalPrice = flowersCount * gladiolusPrice;
                }
            }

            double moneyLeftOrNeeded = Math.Abs(budget - totalPrice);

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowersType} and {moneyLeftOrNeeded:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {moneyLeftOrNeeded:F2} leva more.");
            }
        }
    }
}
