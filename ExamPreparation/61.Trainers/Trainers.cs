using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _61.Trainers
{
    class Trainers
    {
        static void Main(string[] args)
        {
            int numberOfParticipants = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> teams = new Dictionary<string, decimal>();
            teams.Add("Technical", 0m);
            teams.Add("Practical", 0m);
            teams.Add("Theoretical", 0m);
            for (int i = 0; i < numberOfParticipants; i++)
            {
                long distanceInMiles = long.Parse(Console.ReadLine());
                decimal cargoInTons = decimal.Parse(Console.ReadLine());
                string team = Console.ReadLine();
                long distanceInMeters = distanceInMiles * 1600;
                decimal cargoKGs = cargoInTons * 1000m;
                decimal earnedMoney = cargoKGs * 1.5m;
                decimal expences = distanceInMeters * 0.7m * 2.5m;
                decimal total = earnedMoney - expences;
                switch (team)
                {
                    case "Technical":
                        teams["Technical"] += total;
                        break;
                    case "Practical":
                        teams["Practical"] += total;
                        break;
                    case "Theoretical":
                        teams["Theoretical"] += total;
                        break;
                }
            }
            var ordered = teams.OrderByDescending(m => m.Value).Take(1);
            foreach (var winner in ordered)
            {
                Console.WriteLine($"The {winner.Key} Trainers win with ${winner.Value:F3}.");
            }
        }
    }
}
