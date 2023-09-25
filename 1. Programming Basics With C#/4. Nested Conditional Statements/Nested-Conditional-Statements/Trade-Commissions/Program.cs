using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine());

            double commission = 0.0;
            bool invalidSales = false;
            bool invalidTown = false;

            if (town == "sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = sales * 0.05;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = sales * 0.07;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = sales * 0.08;
                }
                else if (sales > 10000)
                {
                    commission = sales * 0.12;
                }
                else
                {
                    invalidSales = true;
                }
            }
            else if (town == "varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = sales * 0.045;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = sales * 0.075;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = sales * 0.10;
                }
                else if (sales > 10000)
                {
                    commission = sales * 0.13;
                }
                else
                {
                    invalidSales = true;
                }
            }
            else if (town == "plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commission = sales * 0.055;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = sales * 0.08;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = sales * 0.12;
                }
                else if (sales > 10000)
                {
                    commission = sales * 0.145;
                }
                else
                {
                    invalidSales = true;
                }
            }
            else
            {
                invalidTown = true;
            }

            if (invalidTown || invalidSales)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{commission:F2}");
            }
        }
    }
}
