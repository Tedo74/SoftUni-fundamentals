using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64.Trainlands
{
    class Wagon
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Wagon(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
    }
    class Trainlands
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Wagon>> trains = new Dictionary<string, List<Wagon>>();
            string input = Console.ReadLine();
            while (input != "It's Training Men!")
            {
                string[] rail = input.Split(new string[] {" -> ", " : "},
                    StringSplitOptions.RemoveEmptyEntries);
                if (rail.Length > 2)
                {
                    string trainName = rail[0];
                    string wagonName = rail[1];
                    int wagonPower = int.Parse(rail[2]);
                    if (!trains.ContainsKey(trainName))
                    {
                        trains.Add(trainName, new List<Wagon>());
                    }
                    trains[trainName].Add(new Wagon(wagonName, wagonPower));
                }
                else if (rail.Length > 1)
                {
                    string firstTrain = rail[0];
                    string otherTrain = rail[1];
                    if (!trains.ContainsKey(firstTrain))
                    {
                        trains.Add(firstTrain, new List<Wagon>());
                    }
                    if (trains[otherTrain].Any())
                    {
                        trains[firstTrain].AddRange(trains[otherTrain]);
                    }
                    trains.Remove(otherTrain);
                }
                else if(rail.Length == 1)
                {
                    string[] rails = rail[0].Split(new string[] {" = "}, StringSplitOptions.RemoveEmptyEntries);
                    string firstTrain = rails[0];
                    string otherTrain = rails[1];
                    if (!trains.ContainsKey(firstTrain))
                    {
                        trains.Add(firstTrain, new List<Wagon>());
                    }
                    if (trains[firstTrain].Any())
                    {
                        trains[firstTrain].Clear();
                    }
                    trains[firstTrain].AddRange(trains[otherTrain]);
                }
                input = Console.ReadLine();
            }
            if (trains.Any())
            {
                var orderedTrains = trains.OrderByDescending(wp => wp.Value.Sum(w => w.Power))
                    .ThenBy(wagons => wagons.Value.Count);
                foreach (var train in orderedTrains)
                {
                    Console.WriteLine($"Train: {train.Key}");
                    foreach (Wagon wagon in train.Value.OrderByDescending(wp => wp.Power))
                    {
                        Console.WriteLine($"###{wagon.Name} - {wagon.Power}");
                    }
                }
            }
        }
    }
}
