using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PointsCounter
{
    class PointsCounter
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string,int>> teams = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "Result")
            {
                string[] inputTokens = Clean(input).Split('|');
                string name;
                string team;
                int points = int.Parse(inputTokens[2]);
                if (IsTeam(inputTokens[0]))
                {
                    team = inputTokens[0];
                    name = inputTokens[1];
                }
                else
                {
                    team = inputTokens[1];
                    name = inputTokens[0];
                }
                if (!teams.ContainsKey(team))
                {
                    teams.Add(team, new Dictionary<string, int>());
                }
                teams[team][name] = points;
                input = Console.ReadLine();
            }
            var OrderedTeams = teams.OrderByDescending(t => t.Value.Sum(p => p.Value));
            foreach (var t in OrderedTeams)
            {
                string team = t.Key;
                int teamPoints = t.Value.Sum(tp => tp.Value);
                var players = t.Value.OrderByDescending(p => p.Value).First();
                Console.WriteLine($"{team} => {teamPoints}");
                Console.WriteLine($"Most points scored by {players.Key}");
            }
        }

        static string Clean(string polluted)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < polluted.Length; i++)
            {
                if (!(polluted[i] == '@'|| polluted[i] == '%' || polluted[i] == '$' || polluted[i] == '*'))
                {
                    sb.Append(polluted[i]);
                }
            }
            return sb.ToString();
        }

        static bool IsTeam(string name)
        {
            return !name.Any(ch => char.IsLower(ch));
        }
    }
}
