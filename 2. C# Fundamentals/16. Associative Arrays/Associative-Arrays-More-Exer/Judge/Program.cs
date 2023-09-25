using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Participant>> contestsParticipants = new Dictionary<string, List<Participant>>();
            Dictionary<string, List<Contest>> participantsResults = new Dictionary<string, List<Contest>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "no more time")
            {
                //"{username} -> {contest} -> {points}"
                string[] contestArgs = command
                    .Split(" -> ");
                string contestName = contestArgs[1];
                Participant participant = new Participant(contestArgs[0], int.Parse(contestArgs[2]));
                bool resultNeedsChange = false;
                if (contestsParticipants.ContainsKey(contestName))
                {
                    int participantIndex = contestsParticipants[contestName].FindIndex(x => x.Name == participant.Name);
                    if (participantIndex != -1 && contestsParticipants[contestName][participantIndex].Points < participant.Points)
                    {
                        contestsParticipants[contestName][participantIndex].Points = participant.Points;
                        resultNeedsChange = true;
                    }
                    else if (participantIndex == -1)
                    {
                        contestsParticipants[contestName].Add(participant);
                    }
                }
                else
                {
                    contestsParticipants.Add(contestName, new List<Participant>() { participant });
                }

                Contest contest = new Contest(contestName, participant.Points);
                if (participantsResults.ContainsKey(participant.Name))
                {
                    int contestIndex = participantsResults[participant.Name].FindIndex(x => x.Name == contestName);
                    if (resultNeedsChange)
                    {
                        participantsResults[participant.Name][contestIndex] = contest;
                    }
                    else
                    {
                        if (contestIndex == -1)
                        {
                            participantsResults[participant.Name].Add(contest);
                        }
                    }
                }
                else
                {
                    participantsResults.Add(participant.Name, new List<Contest>() { contest });
                }
            }
            Dictionary<string, List<Participant>> sortedContests = new Dictionary<string, List<Participant>>();
            foreach (var kvp in contestsParticipants)
            {
                sortedContests[kvp.Key] = kvp.Value
                    .OrderByDescending(x => x.Points)
                    .ThenBy(x => x.Name)
                    .ToList();
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                sortedContests.Select(x => $"{x.Key}: {x.Value.Count} participants{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, x.Value.Select(y => $"{x.Value.IndexOf(y) + 1}. {y.Name} <::> {y.Points}"))}")));

            participantsResults = participantsResults
                .OrderByDescending(x => x.Value.Sum(y => y.Points))
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Individual standings:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, participantsResults.Select(x => $"{participantsResults.Values.ToList().IndexOf(x.Value) + 1}. {x.Key} -> {x.Value.Sum(y => y.Points)}"))}");
        }
    }
}
