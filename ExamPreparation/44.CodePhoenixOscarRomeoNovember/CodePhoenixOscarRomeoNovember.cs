using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _44.CodePhoenixOscarRomeoNovember
{
    class  Creature
    {
        public string Name { get; set; }
        public HashSet<string> Squad { get; set; }

        public Creature(string name)
        {
            this.Name = name;
            this.Squad = new HashSet<string>();
        }
    }
    class CodePhoenixOscarRomeoNovember
    {
        static void Main(string[] args)
        {
            Dictionary<string, Creature> commanders = new Dictionary<string, Creature>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Blaze it!")
                {
                    break;
                }
                string[] names = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                string commander = names[0];
                string squadMate = names[1];
                Creature commanderCreature = new Creature(commander);
                Creature soldier = new Creature(squadMate);
                if (!commanders.ContainsKey(commander))
                {
                   commanders.Add(commander, commanderCreature); 
                }
                if (commanderCreature.Name != soldier.Name)
                {
                    commanders[commander].Squad.Add(squadMate);
                }
            }
            foreach (var c in commanders)
            {
                string name = c.Key;
                List<string> mySquad = c.Value.Squad.ToList();
                foreach (string soldier in mySquad)
                {
                    if (!commanders.ContainsKey(soldier))
                    {
                        continue;
                    }
                    else if(commanders[soldier].Squad.Contains(name))
                    {
                        commanders[soldier].Squad.Remove(name);
                        commanders[name].Squad.Remove(soldier);
                    }
                }
            }

            var orderedCommanders = commanders.OrderByDescending(c => c.Value.Squad.Count);
            int cnt = 0;
            foreach (var cs in orderedCommanders)
            {
                string commanderName = cs.Key;
                List<string> squadMembers = cs.Value.Squad.ToList();
                foreach (string member in squadMembers)
                {
                    cnt++;
                }
                Console.WriteLine($"{commanderName} : {cnt}");
                cnt = 0;
            }
        }
    }
}
