using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TravelCompany
{
    class TravelCompany
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> cities = new Dictionary<string, Dictionary<string, int>>();
            bool isready = false;
            do
            {
                string[] input = Console.ReadLine().Split(':');
                if (input[0] == "ready")
                {
                    isready = true;
                    break;
                }
                string city = input[0];
                string[] vehicleAndCapacity = input[1].Split(',');
                string vehicle = String.Empty;
                int capacity = 0;
                foreach (string v in vehicleAndCapacity)
                {
                    string[] temp = v.Split('-');
                    vehicle = temp[0];
                    capacity = int.Parse(temp[1]);

                    if (!cities.ContainsKey(city))
                    {
                        cities.Add(city, new Dictionary<string, int>());
                    }
                    cities[city][vehicle] = capacity;
                }
            } while (!isready);
            while (true)
            {
                string[] peopleTravel = Console.ReadLine().Split(' ');
                if (peopleTravel[0] == "travel"&& peopleTravel[1] == "time!")
                {
                    break;
                }
                string destination = peopleTravel[0];
                int peopleTravaling = int.Parse(peopleTravel[1]);
                int seats = 0;
                Dictionary<string, int> vehicles = cities[destination];
                foreach (var vehicle in vehicles)
                {
                    seats += vehicle.Value;
                }
                if (seats >= peopleTravaling)
                {
                    Console.WriteLine($"{destination} -> all {peopleTravaling} accommodated");
                }
                else
                {
                    Console.WriteLine($"{destination} -> all except {peopleTravaling - seats} accommodated");
                }
            }
        }
    }
}
