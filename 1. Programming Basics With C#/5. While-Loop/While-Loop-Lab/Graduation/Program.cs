using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade;
            double averageGrade = 0.0;
            int counter = 1;

            while (counter<= 12)
            {
                grade = double.Parse(Console.ReadLine());
                while (grade < 4.00)
                {
                    grade = double.Parse(Console.ReadLine());   
                }
                averageGrade += grade;
                counter++;   
            }
            averageGrade /= 12;
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
        }
    }
}
