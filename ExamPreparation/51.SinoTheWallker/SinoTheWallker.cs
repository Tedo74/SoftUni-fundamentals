using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51.SinoTheWallker
{
    class SinoTheWallker
    {
        static void Main(string[] args)
        {
            string timeFormat = "HH:mm:ss";
            DateTime startTime = DateTime.ParseExact(Console.ReadLine(), timeFormat, CultureInfo.InvariantCulture);
            long stepsToHome = long.Parse(Console.ReadLine());
            int secondsForStep = int.Parse(Console.ReadLine());
            int secondsInDay = 24 * 60 * 60;
            int totalSeconds = (int)((stepsToHome * secondsForStep) % secondsInDay);
            DateTime endTime = startTime.AddSeconds(totalSeconds);
            Console.WriteLine($"Time Arrival: "+endTime.ToString(timeFormat));
        }
    }
}
