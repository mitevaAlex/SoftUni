using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Count => students.Count;

        public int Capacity { get; set; }

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.students.Exists(x => x.FirstName == firstName && x.LastName == lastName))
            {
                this.students.Remove(this.students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            List<Student> wantedStudents = this.students
                .Where(x => x.Subject == subject)
                .ToList();
            if (wantedStudents.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                sb.Append($"{string.Join(Environment.NewLine, wantedStudents.Select(x => $"{x.FirstName} {x.LastName}"))}");
                return sb.ToString();
            }
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
