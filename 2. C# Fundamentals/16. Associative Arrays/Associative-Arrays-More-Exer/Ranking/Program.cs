using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();//stores the contests' names
            //and passwords
            Dictionary<string, List<Contest>> students = new Dictionary<string, List<Contest>>();//stores students' names,
            //competitions and points
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                //"{contest}:{password for contest}"
                string[] competitionData = command
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                contests.Add(competitionData[0], competitionData[1]);
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                //"{contest}=>{password}=>{username}=>{points}"
                string[] studentData = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                Contest contest = new Contest(studentData[0], int.Parse(studentData[3]));
                string password = studentData[1];
                if (contests.ContainsKey(contest.Name) && contests[contest.Name] == password)
                {
                    string username = studentData[2];
                    if (students.ContainsKey(username))
                    {
                        int contestIndex = students[username].FindIndex(x => x.Name == contest.Name);
                        if (contestIndex != -1 && students[username][contestIndex].Points < contest.Points)
                        {
                            students[username][contestIndex].Points = contest.Points;
                        }
                        else if (contestIndex == -1)
                        {
                            students[username].Add(contest);
                        }
                    }
                    else
                    {
                        students.Add(username, new List<Contest>() { contest });
                    }
                }
            }
            students = students
                .OrderByDescending(x => x.Value.Sum(y => y.Points))
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Best candidate is {students.First().Key} with total {students.First().Value.Sum(x => x.Points)} points.");
            SortedDictionary<string, List<Contest>> sortedStudents = new SortedDictionary<string, List<Contest>>();
            foreach (var student in students)
            {
                sortedStudents[student.Key] = student.Value
                    .OrderByDescending(x => x.Points)
                    .ToList();
            }
            Console.WriteLine("Ranking: ");
            Console.WriteLine(string.Join(Environment.NewLine,
                sortedStudents.Select(x => $"{x.Key}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, x.Value)}")));
        }
    }
}
