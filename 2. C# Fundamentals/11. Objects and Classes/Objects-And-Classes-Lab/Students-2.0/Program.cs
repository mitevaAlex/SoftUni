using System;
using System.Collections.Generic;

namespace Students_2._0
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

                if (IsStudentExisting(students, currentStudent.FirstName, currentStudent.LastName))
                {
                    int oldStudentIndex = students.FindIndex(0, students.Count,
                        x => x.FirstName == currentStudent.FirstName && x.LastName == currentStudent.LastName);
                    students[oldStudentIndex] = currentStudent;
                }
                else
                {
                    students.Add(currentStudent);
                }
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

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student currentStudent in students)
            {
                if (currentStudent.FirstName == firstName && currentStudent.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
