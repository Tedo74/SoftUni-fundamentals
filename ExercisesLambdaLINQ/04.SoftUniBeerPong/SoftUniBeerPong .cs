using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SoftUniBeerPong
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> teams = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split('|');
                if (input[0] == "stop the game")
                {
                    break;
                }
                string player = input[0];
                string team = input[1];
                long points = long.Parse(input[2]);
                if (!teams.ContainsKey(team))
                {
                    teams.Add(team, new Dictionary<string, long>());
                }
                if (teams[team].Count < 3)
                {
                    teams[team][player] = points;
                }
            }
            var orderedTeams = teams.Where(players => players.Value.Count == 3)
                .OrderByDescending(pl => pl.Value.Sum(p => p.Value));
            int place = 0;
            foreach (var t in orderedTeams)
            {
                place++;
                var players = t.Value.OrderByDescending(playerPoints => playerPoints.Value);
                Console.WriteLine($"{place}. {t.Key}; Players:");
                foreach (var pp in players)
                {
                    Console.WriteLine($"###{pp.Key}: {pp.Value}");
                }
            }
        }
    }
}
