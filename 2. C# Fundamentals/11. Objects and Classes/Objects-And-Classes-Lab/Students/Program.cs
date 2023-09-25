using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                //"{firstName} {lastName} {age} {homeTown}
                string[] currentStudentData = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Student currentStudent = new Student(currentStudentData[0],
                    currentStudentData[1], int.Parse(currentStudentData[2]), currentStudentData[3]);
                students.Add(currentStudent);
            }
            string requiredTown = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == requiredTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
