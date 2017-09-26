using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetArmada
{
    class HornetArmada
    {
        public static void Main()
        {
            Dictionary<string,long> legionsActivity = new Dictionary<string, long>();
            Dictionary<string, Dictionary<string, long> > soldiers = new Dictionary<string, Dictionary<string, long>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new String[] {" -> ", " = ", ":"},
                    StringSplitOptions.RemoveEmptyEntries);
                long activity = long.Parse(input[0]);
                string legionName = input[1];
                string soldierType = input[2];
                long soldiersCount = long.Parse(input[3]);
                if (!legionsActivity.ContainsKey(legionName))
                {
                    legionsActivity.Add(legionName, activity);
                    soldiers.Add(legionName, new Dictionary<string, long>());
                }

                if (!soldiers[legionName].ContainsKey(soldierType))
                {
                    soldiers[legionName].Add(soldierType, 0);
                }


                soldiers[legionName][soldierType] += soldiersCount;

                if (activity > legionsActivity[legionName])
                {
                    legionsActivity[legionName] = activity;
                }
                
            }
            string[] command = Console.ReadLine().Split('\\');
            if (command.Length > 1)
            {
                int activity = int.Parse(command[0]);
                string solidersType = command[1];
                var orderedLegions = soldiers.Where(l => l.Value.ContainsKey(solidersType))
                    .OrderByDescending(l => l.Value[solidersType]);

                foreach (var l in orderedLegions)
                {
                    if (legionsActivity[l.Key] < activity)
                    {
                        Console.WriteLine($"{l.Key} -> {l.Value[solidersType]}");
                    }
                }
            }
            else
            {
                string solidersType = command[0];
                var orderedLegions = legionsActivity.OrderByDescending(l => l.Value);
                foreach (var l in orderedLegions)
                {
                    if (soldiers[l.Key].ContainsKey(solidersType))
                    {
                        Console.WriteLine($"{l.Value} : {l.Key}");
                    }
                }
            }
        }
    }
}
