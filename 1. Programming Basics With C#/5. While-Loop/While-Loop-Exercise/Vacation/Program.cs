using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());

            int daysSpending = 0;
            int daysPassed = 0;

            while (daysSpending < 5)
            {
                string activity = Console.ReadLine();
                double activityMoney = double.Parse(Console.ReadLine());
                daysPassed++;

                if (activity == "save")
                {
                    moneyAvailable += activityMoney;
                    daysSpending = 0;
                }
                else if(activity == "spend")
                {
                    daysSpending++;
                    if (moneyAvailable <= activityMoney)
                    {
                        moneyAvailable = 0.0;
                    }
                    else
                    {
                        moneyAvailable -= activityMoney;
                    }
                     
                }

                if (moneyNeeded <= moneyAvailable)
                {
                    break;
                }
            }

            if (daysSpending == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysPassed);
            }
            else if(moneyNeeded <= moneyAvailable)
            {
                Console.WriteLine($"You saved the money for {daysPassed} days.");
            }

        }
    }
}
