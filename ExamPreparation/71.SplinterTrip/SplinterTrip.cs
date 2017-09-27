using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _71.SplinterTrip
{
    class SplinterTrip
    {
        static void Main(string[] args)
        {
            double distance = double.Parse(Console.ReadLine());
            double fuelTankCapacity = double.Parse(Console.ReadLine());
            double milesHeavyWind = double.Parse(Console.ReadLine());
            int consumationPerMile = 25;
            distance = distance - milesHeavyWind;
            double totalConsumation = (distance * consumationPerMile) + (milesHeavyWind * consumationPerMile * 1.5);
            totalConsumation += totalConsumation * 0.05;
            Console.WriteLine($"Fuel needed: {totalConsumation:F2}L");
            if (totalConsumation <= fuelTankCapacity)
            {
                Console.WriteLine($"Enough with {Math.Abs(totalConsumation - fuelTankCapacity):F2}L to spare!");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(fuelTankCapacity - totalConsumation):F2}L more fuel.");
            }

        }
    }
}
