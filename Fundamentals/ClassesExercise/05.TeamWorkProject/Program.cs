using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.TeamWorkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsNumber = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(teamsNumber);
            for (int i = 0; i < teamsNumber; i++)
            {
                string[] tokens = Console.ReadLine().Split("-");
                string userName = tokens[0];
                string teamName = tokens[1];
                Team currTeam = new Team(teamName, userName);

                bool isTeamExist = teams.Select(x => x.TeamName).Contains(teamName);
                bool isUserAlreadyCreated = teams.Select(x => x.Creator).Contains(userName);

                if (!isTeamExist && !isUserAlreadyCreated)
                {
                    teams.Add(currTeam);
                    Console.WriteLine($"Team {teamName} has been created by {userName}!");
                }
                else if (isTeamExist)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (isUserAlreadyCreated)
                {
                    Console.WriteLine($"{userName} cannot create another team!");
                }
            }

            string[] memberWhoJoins = Console.ReadLine().Split("->");

            while (memberWhoJoins[0] != "end of assignment")
            {
                string newUser = memberWhoJoins[0];
                string teamName = memberWhoJoins[1];

                bool isTeamExist = teams.Select(x => x.TeamName).Contains(teamName);
                bool isUserAlreadyCreated = teams.Select(x => x.Creator).Contains(newUser);
                bool isMemberExist = teams.Select(x => x.Members).Any(x => x.Contains(newUser));

                if (!isTeamExist)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");

                }
                else if (isUserAlreadyCreated || isMemberExist)
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }
                else
                {
                    int index = teams.FindIndex(x => x.TeamName == teamName);
                    teams[index].Members.Add(newUser);
                }
                memberWhoJoins = Console.ReadLine().Split("->");
            }

            Team[] teamsToDisband = teams
                .OrderBy(x => x.TeamName)
                .Where(x => x.Members.Count == 0)
                .ToArray();
            Team[] fullTeam = teams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .Where(x => x.Members.Count > 0)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in fullTeam)
            {
                sb.AppendLine(team.TeamName);
                sb.AppendLine($"- {team.Creator}");
                foreach (var members in team.Members.OrderBy(x=> x))
                {
                    sb.AppendLine($"-- {members}");
                }
            }
            sb.AppendLine("Teams to disband:");
            foreach (Team team in teamsToDisband)
            {
                sb.AppendLine(team.TeamName);
            }

            Console.WriteLine(sb.ToString());
        }
    }

    class Team
    {
        public Team(string teamName, string creator)
        {
            Members = new List<string>();
            TeamName = teamName;
            Creator = creator;
        }
        public List<string> Members { get; set; }
        public string TeamName { get; set; }
        public string Creator { get; set; }
    }
}
