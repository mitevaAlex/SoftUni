using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, int> participants = new Dictionary<string, int>();//stores participants' 
            //names and highest points
            Dictionary<string, int> languagesSubmissions = new Dictionary<string, int>();//stores languages'
            //names and submissions count
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                //"{username}-{language}-{points}" or "{username}-banned"
                string[] submissionData = command
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = submissionData[0];
                if (submissionData.Contains("banned"))
                {
                    participants.Remove(username);
                    continue;
                }
                string language = submissionData[1];
                int points = int.Parse(submissionData[2]);
                if (!participants.ContainsKey(username))
                {
                    participants.Add(username, 0);
                }

                if (participants[username] < points)
                {
                    participants[username] = points;
                }

                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }
                languagesSubmissions[language]++;
            }
            participants = participants
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");
            Console.WriteLine(string.Join(Environment.NewLine,
                participants.Select(x => $"{x.Key} | {x.Value}")));
            languagesSubmissions = languagesSubmissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Submissions:");
            Console.WriteLine(string.Join(Environment.NewLine, 
                languagesSubmissions.Select(x => $"{x.Key} - {x.Value}")));
        }
    }
}
