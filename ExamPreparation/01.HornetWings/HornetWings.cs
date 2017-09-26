using System;

namespace HornetWings
{
    class HornetWings
    {
        public static void Main()
        {
            long wingFlaps = long.Parse(Console.ReadLine());
            double metersPer1000Flaps = double.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());

            double distance = (wingFlaps / 1000) * metersPer1000Flaps;
            double seconds = (wingFlaps / 100.0);
            double restSeconds = (wingFlaps / endurance) * 5;

            Console.WriteLine($"{distance:F2} m.");
            Console.WriteLine($"{(seconds + restSeconds)} s.");
        }
    }
}
