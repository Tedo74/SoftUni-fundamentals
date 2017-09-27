using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//test
namespace _84.WormsWorldParty
{
    class WormsWorldParty
    {
        static void Main(string[] args)
        {
            List<string> participants = new List<string>();
            Dictionary<string, Dictionary<string, long>> teams = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "quit")
            {
                string[] wormData = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                string wormName = wormData[0];
                string teamName = wormData[1];
                int points =int.Parse(wormData[2]);
                if (participants.Contains(wormName))
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    participants.Add(wormName);
                    if (!teams.ContainsKey(teamName))
                    {
                        teams.Add(teamName, new Dictionary<string, long>());
                    }
                    if (!teams[teamName].ContainsKey(wormName))
                    {
                        teams[teamName].Add(wormName, 0);
                    }
                    teams[teamName][wormName] += points;
                }
                input = Console.ReadLine();
            }
            var orderedWorms = teams.OrderByDescending(w => w.Value.Sum(p => p.Value))
                .ThenBy(w => w.Value.Count);
            int cnt = 1;
            foreach (var w in orderedWorms)
            {
                Console.WriteLine($"{cnt}. Team: {w.Key} - {w.Value.Sum(points => points.Value)}");
                cnt++;
                foreach (var worm in w.Value.OrderByDescending(n => n.Value))
                {
                    Console.WriteLine($"###{worm.Key} : {worm.Value}");
                }
            }
        }
    }
}
