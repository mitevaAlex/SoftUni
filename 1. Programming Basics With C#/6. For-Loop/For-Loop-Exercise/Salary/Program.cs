using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabsCount = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < openTabsCount; i++)
            {
                string siteName = Console.ReadLine();

                if (siteName == "Facebook")
                {
                    salary -= 150;
                }
                else if (siteName == "Instagram")
                {
                    salary -= 100;
                }
                else if (siteName == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                    return;
                }
            }
            Console.WriteLine(salary);
        }
    }
}
