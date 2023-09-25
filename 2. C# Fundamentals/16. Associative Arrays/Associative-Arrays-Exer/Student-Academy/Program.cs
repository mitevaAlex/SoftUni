using System;
using System.Linq;
using System.Collections.Generic;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for (int i = 0; i < studentsCount; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }
            students = students
                .Where(x => x.Value.Average() >= 4.5)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(string.Join(Environment.NewLine,
                students.Select(x => $"{x.Key} -> {x.Value.Average():F2}")));
        }
    }
}
