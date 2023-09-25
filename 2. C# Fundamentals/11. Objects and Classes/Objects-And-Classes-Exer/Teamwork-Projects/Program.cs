using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < teamsCount; i++)
            {
                //"{creatorName}-{teamName}"
                string[] teamData = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);
                Team newTeam = new Team(teamData[0], teamData[1]);
                bool isTeamCreated = IsTeamCreated(teams, newTeam.Name);
                bool doesPersonExist = DoesPersonExist(teams, newTeam.Creator);
                if (isTeamCreated)
                {
                    Console.WriteLine($"Team {newTeam.Name} was already created!");
                }
                else if (doesPersonExist)
                {
                    Console.WriteLine($"{newTeam.Creator} cannot create another team!");
                }
                else
                {
                    Console.WriteLine($"Team {newTeam.Name} has been created by {newTeam.Creator}!");
                    teams.Add(newTeam);
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                //"{memberName}->{teamName}"
                string[] memberData = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                string memberName = memberData[0];
                string teamName = memberData[1];
                bool isTeamCreated = IsTeamCreated(teams, teamName);
                bool doesPersonExist = DoesPersonExist(teams, memberName);
                if (!isTeamCreated)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (doesPersonExist)
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else
                {
                    Team currentTeam = teams.Find(x => x.Name == teamName);
                    currentTeam.Members.Add(memberName);
                }
            }
            List<Team> teamsToDisband = teams.
                Where(x => x.Members.Count == 0)
                .ToList();
            teams = teams
                .Where(x => x.Members.Count != 0)
                .ToList();

            teamsToDisband = teamsToDisband
                .OrderBy(x => x.Name)
                .ToList();
            teams = teams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();
            foreach (Team currentTeam in teams)
            {
                Console.WriteLine($"{currentTeam.Name}\n- {currentTeam.Creator}");
                currentTeam.Members.Sort();
                for (int i = 0; i < currentTeam.Members.Count; i++)
                {
                    Console.WriteLine($"-- {currentTeam.Members[i]}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (Team currentTeam in teamsToDisband)
            {
                Console.WriteLine($"{currentTeam.Name}");
            }
        }

        static bool IsTeamCreated(List<Team> teams, string newTeamName)
        {
            foreach (var currentTeam in teams)
            {
                if (currentTeam.Name == newTeamName)
                {
                    return true;
                }
            }
            return false;
        }

        static bool DoesPersonExist(List<Team> teams, string personName)
        {
            foreach (var currentTeam in teams)
            {
                if (currentTeam.Creator == personName || currentTeam.Members.Contains(personName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
