using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
            int gradesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < gradesCount; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);
                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }

                studentGrades[name].Add(grade);
            }

            Console.WriteLine(string.Join(Environment.NewLine, studentGrades.Select(x => $"{x.Key} -> {string.Join(' ', x.Value.Select(y => $"{y:F2}"))} (avg: {x.Value.Average():F2})")));
        }
    }
}
