using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade = 0.0;
            double averageGrade = 0.0;
            int counter = 1;
            int timesLowGrade = 0;

            while (counter <= 12)
            {
                if (timesLowGrade == 2)
                {
                    break;
                }

                grade = double.Parse(Console.ReadLine());

                if (grade < 4.00)
                {
                    timesLowGrade++;                  
                    continue;
                } 
                averageGrade += grade;
                counter++;
            }
            
            if (timesLowGrade == 2)
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }
            else
            {
                averageGrade /= 12.0;
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
            }
        }
    }
}
