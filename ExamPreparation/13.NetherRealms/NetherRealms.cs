using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.NetherRealms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }
    }
    class NetherRealms
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();
            string healthPattern = @"[^0-9\+\-*\/\.]+";
            string damageNumbersPattern = @"([\-\+]?[\d]+[\.]?\d*)";
            string damageMultyplayerPattern = @"[\*\/]";
            string[] demonNames = Console.ReadLine()
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            Regex health = new Regex(healthPattern);
            foreach (string demon in demonNames)
            {
                MatchCollection matches = health.Matches(demon);
                StringBuilder sb = new StringBuilder();
                foreach (Match match in matches)
                {
                    sb.Append(match.Value);
                }
                int daemonHealth = GetDemonHealth(sb.ToString());

                Regex numbers = new Regex(damageNumbersPattern);
                double damage = 0.0;
                MatchCollection nums = numbers.Matches(demon);
                foreach (Match n in nums)
                {
                    damage += double.Parse(n.Value);
                }
                Regex multyplayer = new Regex(damageMultyplayerPattern);
                MatchCollection multyplayers = multyplayer.Matches(demon);
                foreach (Match sign in multyplayers)
                {
                    if (sign.Value == "/" && damage != 0)
                    {
                        damage /= 2.0;
                    }
                    if (sign.Value == "*")
                    {
                        damage *= 2;
                    }
                }
                Demon demoncho = new Demon(demon, daemonHealth, damage);
                demons.Add(demoncho);
            }
            demons = demons.OrderBy(d => d.Name).ToList();
            foreach (Demon dem in demons)
            {
                Console.WriteLine($"{dem.Name} - {dem.Health} health, {dem.Damage:F2} damage");
            }
        }

        static int GetDemonHealth(string d)
        {
            int health = 0;
            for (int i = 0; i < d.Length; i++)
            {
                health += d[i];
            }
            return health;
        }
    }
}
