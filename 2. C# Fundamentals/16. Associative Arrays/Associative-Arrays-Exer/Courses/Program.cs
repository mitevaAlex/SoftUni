using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                //"{courseName} : {studentName}"
                string[] courseData = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string courseName = courseData[0];
                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                string student = courseData[1];
                courses[courseName].Add(student);
            }

            courses = courses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in courses)
            {
                course.Value.Sort();
            }

            Console.WriteLine(string.Join(Environment.NewLine, 
                courses.Select(x => $"{x.Key}: {x.Value.Count}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, x.Value.Select(y => $"-- {y}"))}")));
        }
    }
}
