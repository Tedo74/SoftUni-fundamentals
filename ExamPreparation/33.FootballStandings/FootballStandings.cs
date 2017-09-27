using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _33.FootballStandings
{
   class FootballStandings
    {
        static string RepairString(string r)
        {
            char[] c = r.ToCharArray();
            Array.Reverse(c);
            string ready = new string(c).ToUpper();
            return ready;
        }
        public static void Main()
        {
            string delimeter = Console.ReadLine();
            string escapedDelimeter = Regex.Escape(delimeter);
            string patternTeams = string.Format
             //(@"{0}(?<teamA>[a-zA-Z]*){0}.*{0}(?<teamB>[a-zA-Z]*){0}[^ ]* (?<goalsA>\d+):(?<goalsB>\d+)", escapedDelimeter);
             (@"(?<teamA>(?<={0})[A-Za-z]*(?={0}))(?:.*)(?<teamB>(?<={0})[A-Za-z]*(?={0}))(?:[^ ]*) (?<goalsA>\d+):(?<goalsB>\d+)", escapedDelimeter);
            Regex findTeams = new Regex(patternTeams);
            string input = Console.ReadLine();
            Dictionary<string, int> teamPoints = new Dictionary<string, int>();
            Dictionary<string, int> goalsByTeam = new Dictionary<string, int>();
            while (input != "final")
            {
                Match teams = findTeams.Match(input);
                string teamA = RepairString(teams.Groups["teamA"].Value);
                string teamB = RepairString(teams.Groups["teamB"].Value);
                int teamAGoals = int.Parse(teams.Groups["goalsA"].Value);
                int teamBGoals = int.Parse(teams.Groups["goalsB"].Value);

                if (!teamPoints.ContainsKey(teamA))
                {
                    teamPoints.Add(teamA, 0);
                    goalsByTeam.Add(teamA, 0);
                }
                
                if (!teamPoints.ContainsKey(teamB))
                {
                    teamPoints.Add(teamB, 0);
                    goalsByTeam.Add(teamB, 0);
                }
                
                if (teamAGoals > teamBGoals)
                {
                    teamPoints[teamA] += 3;
                }
                else if (teamAGoals < teamBGoals)
                {
                    teamPoints[teamB] += 3;
                }
                else if (teamAGoals == teamBGoals)
                {
                    teamPoints[teamA] += 1;
                    teamPoints[teamB] += 1;
                }
                goalsByTeam[teamA] += teamAGoals;
                goalsByTeam[teamB] += teamBGoals;

                input = Console.ReadLine();
            }

            var classification = teamPoints.OrderByDescending(p => p.Value).ThenBy(n => n.Key);
            Console.WriteLine("League standings:");
            int cnt = 0;
            foreach (var team in classification)
            {
                cnt++;
                Console.WriteLine($"{cnt}. {team.Key} {team.Value}");
            }
            Console.WriteLine("Top 3 scored goals:");
            var teamsOrderedByGoals = goalsByTeam.OrderByDescending(p => p.Value).ThenBy(n => n.Key).Take(3);
            foreach (var teamsGoals in teamsOrderedByGoals)
            {
                Console.WriteLine($"- {teamsGoals.Key} -> {teamsGoals.Value}");
            }
        }
    }
}
