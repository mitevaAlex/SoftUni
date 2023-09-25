using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judgesCount = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double presentationAverageGrade = 0.0;
            double totalAverageGrade = 0.0;
            int whileLoopCounter = 0;

            while (presentationName != "Finish")
            {
                whileLoopCounter++;
                presentationAverageGrade = 0.0;
                for (int judgeNumber = 1; judgeNumber <= judgesCount; judgeNumber++)
                {
                    double currentGrade = double.Parse(Console.ReadLine());
                    presentationAverageGrade += currentGrade;
                    totalAverageGrade += currentGrade;
                }
                presentationAverageGrade /= judgesCount;
                Console.WriteLine($"{presentationName} - {presentationAverageGrade:F2}.");
                presentationName = Console.ReadLine();
            }
            totalAverageGrade /= whileLoopCounter * judgesCount;
            Console.WriteLine($"Student's final assessment is {totalAverageGrade:F2}.");
        }
    }
}
