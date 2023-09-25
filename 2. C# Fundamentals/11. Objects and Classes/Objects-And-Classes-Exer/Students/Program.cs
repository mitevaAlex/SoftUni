using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < studentsCount; i++)
            {
                //"{first name} {last name} {grade}"
                string[] currentStudentData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Student currentStudent = new Student(currentStudentData[0],
                    currentStudentData[1], double.Parse(currentStudentData[2]));
                students.Add(currentStudent);
            }
            List<Student> orderedStudents = students
                .OrderByDescending(x => x.Grade)
                .ToList();
            orderedStudents.ForEach(x => Console.WriteLine(x));
        }
    }
}
