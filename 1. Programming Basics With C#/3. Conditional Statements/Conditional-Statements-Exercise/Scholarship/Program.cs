using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            bool socialScholarship = false;
            bool excellentReasultsScholarship = false;
            double socialScholarshipMoney = 0;
            double excellentReasultsScholarshipMoney = 0;

            if (income < minSalary && averageGrade >= 4.5 )
            {
                socialScholarship = true;
                socialScholarshipMoney = 0.35 * minSalary;
            }

            if (averageGrade >= 5.50)
            {
                excellentReasultsScholarship = true;
                excellentReasultsScholarshipMoney = 25 * averageGrade;
            }

            if (!socialScholarship && !excellentReasultsScholarship)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if ((socialScholarship && excellentReasultsScholarship) 
                && excellentReasultsScholarshipMoney >= socialScholarshipMoney)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentReasultsScholarshipMoney)} BGN");
            }
            else if ((socialScholarship && excellentReasultsScholarship) 
                && excellentReasultsScholarshipMoney < socialScholarshipMoney)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarshipMoney)} BGN");
            }
            else if (excellentReasultsScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentReasultsScholarshipMoney)} BGN");
            }
            else
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarshipMoney)} BGN");
            }
        }
    }
}
