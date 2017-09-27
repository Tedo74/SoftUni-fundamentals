using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace _53.EnduranceRally
{
    class TrackPoint
    {
        public double Fuel { get; set; }
        public bool IsCheckpoint { get; set; }

        public TrackPoint(double fuel)
        {
            this.Fuel = fuel;
            IsCheckpoint = false;
        }
    }
    class EnduranceRally
    {
        static void Main(string[] args)
        {
            string[] driversNames = Console.ReadLine().Split(' ');
            TrackPoint[] track = Console.ReadLine().Split(' ').Select(n =>new TrackPoint(double.Parse(n))).ToArray();
            int[] checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (checkpoints.Any())
            {
                for (int i = 0; i < checkpoints.Length; i++) // set checkPoints
                {
                    int index = checkpoints[i];
                    if (index >= 0 && index < track.Length)
                    {
                        track[index].IsCheckpoint = true;
                    }
                }
            }
            foreach (var driver in driversNames)
            {
                Run(driver, track);
            }

        }

        public static void Run(string name, TrackPoint[] track)
        {
            double carFuel = name[0];
            bool hasFuel = true;
            int lastRichedIndex = -1;
            for (int i = 0; i < track.Length; i++)
            {
                if (carFuel > 0)
                {
                    if (track[i].IsCheckpoint)
                    {
                        carFuel += track[i].Fuel;
                    }
                    else
                    {
                        carFuel -= track[i].Fuel;
                    }
                }
                if (carFuel <= 0)
                {
                    hasFuel = false;
                    lastRichedIndex = i;
                    break;
                }
            }
            if (hasFuel)
            {
                Console.WriteLine($"{name} - fuel left {carFuel:F2}");
            }
            else
            {
                Console.WriteLine($"{name} - reached {lastRichedIndex}");
            }
        }
    }
}
