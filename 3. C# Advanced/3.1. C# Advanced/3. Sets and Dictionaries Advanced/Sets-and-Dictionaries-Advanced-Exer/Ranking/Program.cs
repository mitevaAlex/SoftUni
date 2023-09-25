using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();
            string command = "";
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] contestArgs = command
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                contestPasswords.Add(contestArgs[0], contestArgs[1]);
            }

            SortedDictionary<string, Dictionary<string, int>> students = new SortedDictionary<string, Dictionary<string, int>>();
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] contestArgs = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = contestArgs[0];
                string password = contestArgs[1];
                if (contestPasswords.ContainsKey(contest) && contestPasswords[contest] == password)
                {
                    string student = contestArgs[2];
                    int points = int.Parse(contestArgs[3]);
                    if (!students.ContainsKey(student))
                    {
                        students.Add(student, new Dictionary<string, int>());
                    }

                    if (students[student].ContainsKey(contest))
                    {
                        if (students[student][contest] < points)
                        {
                            students[student][contest] = points;
                        }
                    }
                    else
                    {
                        students[student].Add(contest, points);
                    }
                }
            }

            string bestStudent = students
                .OrderByDescending(x => x.Value.Select(y => y.Value).Sum())
                .First()
                .Key;
            int bestPoints = students[bestStudent]
                .Select(x => x.Value)
                .Sum();
            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}");
                Dictionary<string, int> contestPoints = students[student.Key]
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine(string.Join(Environment.NewLine, contestPoints.Select(x => $"#  {x.Key} -> {x.Value}")));
            }
        }
    }
}
