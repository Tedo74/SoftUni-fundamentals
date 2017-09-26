using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CharityMarathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            long trackLengthMeters = long.Parse(Console.ReadLine());
            int cpacityOfTrack = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            int maxCapacity = cpacityOfTrack * days;
            runners = Math.Min(maxCapacity, runners);
            long totalMeters = runners * laps * trackLengthMeters;
            long totalKm = totalMeters / 1000;
            double money = moneyPerKm * totalKm;
            Console.WriteLine($"Money raised: {money:F2}");
        }
    }
}
