using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLowGrades = int.Parse(Console.ReadLine());

            int counterLowGrades = 0;
            double averageGrade = 0.0;
            int numberExercises = 0;
            string lastExerciseName = string.Empty;
            bool enoughWritten = false;

            while (counterLowGrades < numLowGrades)
            {
                string currentExerciseName = Console.ReadLine();
                if (currentExerciseName == "Enough")
                {
                    enoughWritten = true;
                    break;
                }
                lastExerciseName = currentExerciseName;

                double grade = double.Parse(Console.ReadLine());
                if (grade <= 4.00)
                {
                    counterLowGrades++;
                }
                averageGrade += grade;
                numberExercises++; 
            }

            if (enoughWritten)
            {
                averageGrade /= numberExercises;
                Console.WriteLine($"Average score: {averageGrade:F2}");
                Console.WriteLine($"Number of problems: {numberExercises}");
                Console.WriteLine($"Last problem: {lastExerciseName}");
            }
            else
            {
                Console.WriteLine($"You need a break, {counterLowGrades} poor grades.");
            }

        }
    }
}
