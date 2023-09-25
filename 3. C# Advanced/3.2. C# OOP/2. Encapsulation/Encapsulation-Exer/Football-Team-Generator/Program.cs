using System;
using System.Collections.Generic;

namespace Football_Team_Generator
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] args = command
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string operation = args[0];
                    string teamName = args[1];
                    switch (operation)
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            teams.Add(teamName, team);
                            break;
                        case "Add":
                            DoesTeamExist(teamName, teams);
                            teams[teamName].AddPlayer(args[2], int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5]), int.Parse(args[6]), int.Parse(args[7]));
                            break;
                        case "Remove":
                            DoesTeamExist(teamName, teams);
                            teams[teamName].RemovePlayer(args[2]);
                            break;
                        case "Rating":
                            DoesTeamExist(teamName, teams);
                            Console.WriteLine(teams[teamName]);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        static void DoesTeamExist(string teamName, Dictionary<string, Team> teams)
        {
            if (!teams.ContainsKey(teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
