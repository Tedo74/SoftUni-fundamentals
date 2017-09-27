using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81.Wormtest
{
    class Wormtest
    {
        static void Main(string[] args)
        {
            int wormLengthInMeters = int.Parse(Console.ReadLine());
            double wormWidth = double.Parse(Console.ReadLine());
            int wormLengthCm = wormLengthInMeters * 100;
            double reminder = wormLengthCm % wormWidth;
            if (reminder != 0 && wormWidth != 0 && wormLengthCm != 0)
            {
                double result = Math.Round(wormLengthCm / wormWidth * 100.0, 2);
                Console.WriteLine($"{result:F2}%");
            }
            else
            {
                double result = Math.Round(wormLengthCm * wormWidth, 2);
                Console.WriteLine($"{result:F2}");
            }
        }
    }
}
